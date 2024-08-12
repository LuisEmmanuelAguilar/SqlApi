using Company.Core.WebService.AspNetCore.Authorization;
using Company.Core.WebService.Contracts;
using Company.Core.WebService.Contracts.Exceptions;
using SqlApi.AsyncService.Common.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SqlApi.AsyncService.Common.DataAccess;
using SqlApi.AsyncService.Common.DataAdapters;
using SqlApi.AsyncService.Common.DataAccess.Models;
using Company.Records.Validation;
using Microsoft.Extensions.Localization;
using System.Globalization;
using SqlApi.AsyncService.Common.BusinessLogic;
using SqlApi.AsyncService.Common;
using System.Collections.Generic;

namespace SqlApi.AsyncService.BusinessLogic
{
    /// <summary>
    /// A service for interacting with query jobs
    /// </summary>
    public class JobService : IJobService
    {
        private readonly IJobStatusService _jobStatusService;
        private readonly IJobThrottlingService _jobThrottlingService;
        private readonly IJobDataAdapter _jobDataAdapter;
        private readonly IAzureStorageAdapter _azureStorageAdapter;
        private readonly IRequestContext _requestContext;
        private readonly IBackendDataAdapter _backendAdapter;
        private readonly ValidationHelperFactory _validationHelperFactory;
        private readonly IStringLocalizer _localizer;
        private readonly ILogger _logger;

        private readonly AsyncRetryPolicy _preconditionFailedRetryPolicy = Policy
            .Handle<CosmosException>(ex => ex.StatusCode == HttpStatusCode.PreconditionFailed)
            .RetryAsync(5);

        /// <summary>
        /// Constructs a JobService
        /// </summary>
        public JobService(
            IJobStatusService jobStatusService,
            IJobThrottlingService jobThrottlingService,
            IJobDataAdapter jobDataAdapter,
            IAzureStorageAdapter azureStorageAdapter,
            IRequestContext requestContext,
            IBackendDataAdapter backendDataAdapter,
            ValidationHelperFactory validationHelperFactory,
            IStringLocalizer<JobService> localizer,
            ILogger<JobService> logger)
        {
            _jobStatusService = jobStatusService;
            _jobThrottlingService = jobThrottlingService;
            _jobDataAdapter = jobDataAdapter ?? throw new ArgumentNullException(nameof(jobDataAdapter));
            _azureStorageAdapter = azureStorageAdapter ?? throw new ArgumentNullException(nameof(azureStorageAdapter));
            _requestContext = requestContext ?? throw new ArgumentNullException(nameof(requestContext));
            _backendAdapter = backendDataAdapter ?? throw new ArgumentNullException(nameof(backendDataAdapter));
            _validationHelperFactory = validationHelperFactory;
            _localizer = localizer;
            _logger = logger;

        }

        /// <inheritdoc/>
        public async Task<CreateJobResponse> CreateJob(CreateJobRequest request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);

            var job = new JobDocument
            {
                Id = request.JobId ?? Guid.NewGuid().ToString(),
                CommandId = request.CommandId,
                Description = request.Description,
                Product = request.Product,
                SqlParameters = request.SqlParameters,
                UserId = request.UserId,
                UXMode = request.UXMode,
                Culture = request.Culture,
                InstalledCountry = request.InstalledCountry,
                DataSetOptions = request.DataSetOptions,
                Audience = _requestContext.TrustedCallerClientName,
                // Map request.CommandService to JobDocument.CommandService as long as it's not the same value going to JobDocument.Audience (no need to store twice in that case)
                CommandService = request.CommandService == _requestContext.TrustedCallerClientName ? null : request.CommandService,
                PartitionKey = _requestContext.EnvironmentId,
                Status = JobStatus.Pending,
                SendNotification = request.SendNotification,
                NotificationInfo = request.NotificationInfo,
            };

            var (reasonThrottled, throttleMessage) = await _jobThrottlingService.ThrottleAsync(job, _requestContext, cancellationToken);

            var now = DateTime.UtcNow;
            job.CreateDate = now;
            job.Heartbeat = now;
            if (job.UXMode == UXMode.Synchronous) job.UXHeartbeat = now;

            await _jobDataAdapter.UpsertJob(job, cancellationToken);

            if (job.Status == JobStatus.Pending)
            {
                try
                {
                    await _backendAdapter.QueueQueryExecutionAsync(job, cancellationToken);
                }
                catch (Exception queueQueryExecutionException)
                {
                    // TODO Consider selectively not marking as failed for some exceptions
                    //  Future: Could allow retry after pending beyond retry threshold
                    try
                    {
                        await _jobStatusService.MarkJobFailed(job, cancellationToken);
                    }
                    catch (Exception markFailedException)
                    {
                        if (markFailedException is not OperationCanceledException)
                        {
                            _logger.LogWarning(markFailedException, "An error occurred marking job failed.  JobId: {JobId}", job.Id);
                        }
                        job.Status = JobStatus.Pending;
                    }

                    var errorMessage = $"An exception occurred attempting to start background job for {job.Product} Query. JobId: {job.Id}  CommandId: {job.CommandId}";
                    if (job.Status != JobStatus.Pending)
                    {
                        throw new RequestFailException(errorMessage, queueQueryExecutionException);
                    }
                    else
                    {
                        _logger.LogError(queueQueryExecutionException, errorMessage);
                    }
                }
            }

            // 24060700 = created pending job
            // 24060720 = created job throttled for user
            // 24060721 = created job throttled for environment
            var jobCreatedEventId = 24060700 + (job.Status == JobStatus.Throttled ? (20 + (reasonThrottled == ThrottleReason.EnvironmentLimit ? 1 : 0)) : 0);

            _logger.LogInformation(jobCreatedEventId, "Created job {JobId} (Audience {Audience}, Command service {CommandService}, Command id {CommandId}, Environment id {EnvironmentId}, Product {Product}, UserId {UserId}, Status {Status})",
                job.Id, _requestContext.TrustedCallerClientName, request.CommandService ?? _requestContext.TrustedCallerClientName, request.CommandId, _requestContext.EnvironmentId, request.Product, request.UserId, job.Status);

            return new CreateJobResponse { Id = job.Id, Status = job.Status, Message = throttleMessage };
        }

        private void ValidateRequest(CreateJobRequest request)
        {
            var validationHelper = _validationHelperFactory.CreateValidationHelper();

            validationHelper.ValidateRequiredField(request.CommandId, "command_id");
            validationHelper.ValidateValueFormat(Guid.TryParse(request.CommandId, out _), request.CommandId, "command_id");

            validationHelper.ValidateOptionalField(request.UserId, "user_id");
            validationHelper.ValidateOptionalField(request.Description, "description");
            validationHelper.ValidateValidEnumValue(request.Product, "product");
            validationHelper.ValidateValidEnumValue(request.UXMode, "ux_mode");

            validationHelper.ValidateOptionalField(request.JobId, "job_id");
            if (request.JobId != null)
            {
                validationHelper.ValidateValueFormat(Guid.TryParse(request.JobId, out _), request.JobId, "job_id");
            }

            validationHelper.ValidateOptionalCollection(request.SqlParameters, "sql_parameters", coll => { });

            // DataSetOptions may contain null items, so can't call ValidateOptionalCollection for it     
            if (request.DataSetOptions != null)
            {
                var fileNamesSet = new HashSet<string>();
                var dataSetOptionsIndex = -1;
                foreach (var dataSetOptions in request.DataSetOptions)
                {
                    var dataSetOptionsItemName = $"data_set_options[{++dataSetOptionsIndex}]";

                    if (dataSetOptions != null)
                    {
                        validationHelper.ValidateValidEnumValue(dataSetOptions.OutputFormat, $"{dataSetOptionsItemName}.output_format");
                        validationHelper.ValidateOptionalCollection(dataSetOptions.FormattingOptions, $"{dataSetOptionsItemName}.formatting_options", coll => { });
                        if (string.IsNullOrEmpty(dataSetOptions.FileName))
                        {
                            var fileName = $"results_{dataSetOptionsIndex + 1}";
                            validationHelper.Validate(!fileNamesSet.Add(fileName), _localizer.GetString(nameof(ErrorCode.DataSetOptionsFileNamesMustBeUnique)), ErrorCode.DataSetOptionsFileNamesMustBeUnique, $"{dataSetOptionsItemName}.file_name");
                        }
                        else
                        {
                            if (dataSetOptions.FileName.EndsWith($".{dataSetOptions.OutputFormat}", StringComparison.OrdinalIgnoreCase))
                            {
                                dataSetOptions.FileName = dataSetOptions.FileName[..^$".{dataSetOptions.OutputFormat}".Length];
                            }
                            validationHelper.ValidateOptionalField(dataSetOptions.FileName, $"{dataSetOptionsItemName}.file_name");
                            validationHelper.Validate(!fileNamesSet.Add(dataSetOptions.FileName), _localizer.GetString(nameof(ErrorCode.DataSetOptionsFileNamesMustBeUnique)), ErrorCode.DataSetOptionsFileNamesMustBeUnique, $"{dataSetOptionsItemName}.file_name");
                        }
                        if (dataSetOptions.FormattingOptions != null)
                        {
                            var formattingOptionsIndex = -1;
                            foreach (var fieldFormatOptions in dataSetOptions.FormattingOptions)
                            {
                                var formattingOptionsItemName = $"{dataSetOptionsItemName}.formatting_options[{++formattingOptionsIndex}]";
                                validationHelper.ValidateRequiredField(fieldFormatOptions.Name, $"{formattingOptionsItemName}.name");
                                validationHelper.ValidateValidEnumValue(fieldFormatOptions.Format, $"{formattingOptionsItemName}.format");
                                validationHelper.ValidateValidEnumValue(fieldFormatOptions.LegacyFormatDescriptor, $"{formattingOptionsItemName}.legacy_format_descriptor");
                                validationHelper.ValidateValidEnumValue(fieldFormatOptions.DecryptMode, $"{formattingOptionsItemName}.decrypt_mode");

                                validationHelper.Validate(fieldFormatOptions.Format == FieldFormat.Legacy && fieldFormatOptions.LegacyFormatDescriptor == LegacyFormatDescriptor.None,
                                    _localizer.GetString(nameof(ErrorCode.FieldFormatOptionsLegacyRequiresFormatDescriptor)), ErrorCode.FieldFormatOptionsLegacyRequiresFormatDescriptor,
                                    formattingOptionsItemName);
                                validationHelper.Validate(fieldFormatOptions.Format != FieldFormat.Legacy && fieldFormatOptions.LegacyFormatDescriptor != LegacyFormatDescriptor.None,
                                    _localizer.GetString(nameof(ErrorCode.FieldFormatOptionsNonLegacyShouldNotSpecifyFormatDescriptor)), ErrorCode.FieldFormatOptionsNonLegacyShouldNotSpecifyFormatDescriptor,
                                    formattingOptionsItemName);
                            }

                            validationHelper.Validate(dataSetOptions.FormattingOptions.Select(options => options.Name).Distinct().Count() != dataSetOptions.FormattingOptions.Count,
                                _localizer.GetString(nameof(ErrorCode.DataSetOptionsFieldNamesMustBeUnique)), ErrorCode.DataSetOptionsFieldNamesMustBeUnique, dataSetOptionsItemName);
                        }
                    }
                }
            }

            validationHelper.ValidateOptionalField(request.Culture, "culture");
            validationHelper.ValidateValueFormat(IsValidCulture(request.Culture), request.Culture, "culture");

            validationHelper.ValidateValidEnumValue(request.InstalledCountry, "installed_country");

            validationHelper.ValidateOptionalField(request.CommandService, "command_service");

            validationHelper.Validate((request.SendNotification && request.UserId == null), _localizer.GetString(nameof(ErrorCode.NotificationMustIncludeUserId)), ErrorCode.NotificationMustIncludeUserId, "send_notification");
            validationHelper.Validate((request.NotificationInfo != null && request.UserId == null), _localizer.GetString(nameof(ErrorCode.NotificationMustIncludeUserId)), ErrorCode.NotificationMustIncludeUserId, "notification_info");
        }

        private static bool IsValidCulture(string culture)
        {
            var cultureInfo = CultureInfo.GetCultureInfo(culture);
            // Apparently you can create a CultureInfo for any random string you want, but its LCID will be 4096 if it's not a "real" culture.
            return cultureInfo.LCID != 4096;
        }

        /// <inheritdoc/>
        public async Task<Job> GetJob(string id, string requestId, IncludeReadUrl includeReadUrl, BlobContentDisposition contentDisposition, CancellationToken cancellationToken = default)
        {
            using var scope = _logger.BeginScope(new Dictionary<string, object>
            {
                ["JobId"] = id
            });

            var jobDocument = await _preconditionFailedRetryPolicy.ExecuteAsync(async () =>
            {
                var jobDocument = await _jobDataAdapter.GetJob(id, _requestContext.EnvironmentId, cancellationToken) ?? throw new RecordNotFoundV2Exception("Job record not found");

                CommonExceptions.ValidateRequestId(requestId, jobDocument, _logger);
                AuthorizationHelper.AuthorizeJobAccess(jobDocument, _requestContext);

                await UpdateHeartbeat(jobDocument, cancellationToken);

                return jobDocument;
            });

            return await MapJob<Job>(jobDocument, includeReadUrl, contentDisposition, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<T> MapJob<T>(JobDocument jobDocument, IncludeReadUrl includeReadUrl, BlobContentDisposition contentDisposition, CancellationToken cancellationToken)
            where T : Job, new()
        {
            var job = new T
            {
                Audience = jobDocument.Audience,
                CommandService = jobDocument.CommandService ?? jobDocument.Audience,
                CommandId = jobDocument.CommandId,
                SqlParameters = jobDocument.SqlParameters,
                Description = jobDocument.Description,
                EnvironmentId = jobDocument.PartitionKey,
                CreateDate = jobDocument.CreateDate,
                RunDate = jobDocument.RunDate,
                EndDate = jobDocument.EndDate,
                Id = jobDocument.Id,
                Product = jobDocument.Product,
                Status = jobDocument.Status,
                UserId = jobDocument.UserId,
                UXMode = jobDocument.UXMode,
                Culture = jobDocument.Culture,
                InstalledCountry = jobDocument.InstalledCountry,
                DataSetOptions = jobDocument.DataSetOptions,
                ErrorMessage = jobDocument.ErrorMessage
            };

            if ((includeReadUrl != IncludeReadUrl.Never && (job.Status == JobStatus.Cancelled || job.Status == JobStatus.Completed))
             || (includeReadUrl == IncludeReadUrl.OnceRunning && (job.Status == JobStatus.Running || job.Status == JobStatus.Cancelling)))
            {
                job.SasUris = await _azureStorageAdapter.GetBlobReadUrisAsync(jobDocument, contentDisposition, cancellationToken);
            }

            return job;
        }

        /// <inheritdoc/>
        public async Task<string> GetBlobWriteUriAsync(string id, int sequence, string requestId, CancellationToken cancellationToken = default)
        {
            using var scope = _logger.BeginScope(new Dictionary<string, object>
            {
                ["JobId"] = id
            });

            var jobDocument = await _jobDataAdapter.GetJob(id, _requestContext.EnvironmentId, cancellationToken) ?? throw new RecordNotFoundV2Exception("Job record not found");

            CommonExceptions.ValidateRequestId(requestId, jobDocument, _logger);

            if (jobDocument.Status != JobStatus.Running)
            {
                _logger.LogInformation("A blob write uri may not be requested while the job is in the current status. Status: {Status}", jobDocument.Status);
                CommonExceptions.ThrowUnexpectedStatusConflict(jobDocument.Status);
            }

            return await _azureStorageAdapter.GetBlobWriteUriAsync(jobDocument, sequence, cancellationToken);
        }

        private async Task UpdateHeartbeat(JobDocument jobDocument, CancellationToken cancellationToken)
        {
            // If the backend is calling this, we want to update the heartbeat to let resiliency know it's still alive
            if (_requestContext.RequestAuthorizationType == RequestAuthorizationType.SecurityAuthorizationService &&
                _requestContext.HasServiceAuthorizationScope(AuthorizationHelper.BackendScope))
            {
                jobDocument.Heartbeat = DateTime.UtcNow;
                await _jobDataAdapter.UpsertJob(jobDocument, cancellationToken);
            }
            else if (UpdateUXHeartbeat(jobDocument))
            {
                jobDocument.UXHeartbeat = DateTime.UtcNow;
                await _jobDataAdapter.UpsertJob(jobDocument, cancellationToken);
            }
        }

        private bool UpdateUXHeartbeat(JobDocument jobDocument)
        {
            return jobDocument.UXMode == UXMode.Synchronous &&
                    (jobDocument.Status == JobStatus.Pending || jobDocument.Status == JobStatus.Running) &&
                   ((_requestContext.RequestAuthorizationType == RequestAuthorizationType.SecurityAuthorizationService &&
                     _requestContext.HasServiceAuthorizationScope(AuthorizationHelper.ConsumerScope)) ||
                    _requestContext.RequestAuthorizationType == RequestAuthorizationType.CompanyId);
        }
    }
}
