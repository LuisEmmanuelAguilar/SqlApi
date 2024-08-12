using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlApi.AsyncService.Common.BusinessLogic
{
    internal class JobThrottlingService
    {
    }
}
using Company.Core.WebService.Contracts;
using Company.Core.WebService.Contracts.Exceptions;
using SqlApi.AsyncService.Common.DataAccess;
using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.DataAdapters;
using SqlApi.AsyncService.Common.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;

namespace SqlApi.AsyncService.Common.BusinessLogic
{
    /// <inheritdoc/>
    public class JobThrottlingService : IJobThrottlingService
    {
        private readonly IJobStatusServiceBase _jobStatusService;
        private readonly IJobDataAdapter _jobDataAdapter;
        private readonly IBackendDataAdapter _backendAdapter;
        private readonly IStringLocalizer _localizer;
        private readonly ILogger _logger;

        private readonly Dictionary<Product, IDictionary<string, int>> _maxConcurrency = new();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jobStatusService"></param>
        /// <param name="jobDataAdapter"></param>
        /// <param name="backendDataAdapter"></param>
        /// <param name="configuration"></param>
        /// <param name="localizer"></param>
        /// <param name="logger"></param>
        public JobThrottlingService(
            IJobStatusServiceBase jobStatusService,
            IJobDataAdapter jobDataAdapter,
            IBackendDataAdapter backendDataAdapter,
            IConfiguration configuration,
            IStringLocalizer<JobThrottlingService> localizer,
            ILogger<JobThrottlingService> logger)
        {
            _jobStatusService = jobStatusService;
            _jobDataAdapter = jobDataAdapter;
            _backendAdapter = backendDataAdapter;
            _localizer = localizer;
            _logger = logger;

            var section = configuration.GetSection("MaxJobConcurrency");
            foreach (var productSection in section.GetChildren())
            {
                if (Enum.TryParse<Product>(productSection.Key, out var product))
                {
                    _maxConcurrency.Add(product, new Dictionary<string, int>()
                    {
                        { "User", productSection.GetValue("User", 2) },
                        { "Environment", productSection.GetValue("Environment", 10) },
                        { "UserQueued", productSection.GetValue("UserQueued", 20) }
                    });
                }
            }
        }

        /// <inheritdoc/>
        public async Task<(ThrottleReason Reason, string Message)> ThrottleAsync(JobDocument job, IRequestContext requestContext, CancellationToken cancellationToken)
        {
            ThrottleReason reason = default;
            string message = null;
            var statusesToCount = new[] { JobStatus.Pending, JobStatus.Running, JobStatus.Throttled };
            var counts = await _jobDataAdapter.GetJobCountsAsync(job.Product, job.PartitionKey, statusesToCount, string.IsNullOrEmpty(job.UserId) ? null : new[] { job.UserId }, cancellationToken);

            switch (job.UXMode)
            {
                case UXMode.Synchronous:
                    if (!string.IsNullOrEmpty(job.UserId) && counts[job.UserId] >= _maxConcurrency[job.Product]["User"])
                    {
                        _logger.LogInformation(24060710, "Throttled job for user {UserId} (Audience {Audience}, Command service {CommandService}, Environment id {EnvironmentId}, Product {Product})",
                            job.UserId, job.Audience, job.CommandService ?? job.Audience, requestContext.EnvironmentId, job.Product);
                        throw new TooManyRequestsException(_localizer.GetString("Synchronous_ThrottledByUser"));
                    }
                    else if (counts[job.PartitionKey] >= _maxConcurrency[job.Product]["Environment"])
                    {
                        _logger.LogInformation(24060711, "Throttled job for environment {EnvironmentId} (Audience {Audience}, Command service {CommandService}, Product {Product}, UserId {UserId})",
                            requestContext.EnvironmentId, job.Audience, job.CommandService ?? job.Audience, job.Product, job.UserId);
                        throw new TooManyRequestsException(_localizer.GetString("Synchronous_ThrottledByEnvironment"));
                    }
                    break;

                case UXMode.Asynchronous:
                    if (!string.IsNullOrEmpty(job.UserId) && counts[job.UserId] >= _maxConcurrency[job.Product]["User"])
                    {
                        // Don't let users queue an unlimited number of jobs.
                        if (counts[job.UserId] >= _maxConcurrency[job.Product]["UserQueued"])
                        {
                            _logger.LogInformation(24060712, "Throttled job for user {UserId} exceeding throttled job limit (Audience {Audience}, Command service {CommandService}, Environment id {EnvironmentId}, Product {Product})",
                                job.UserId, job.Audience, job.CommandService ?? job.Audience, requestContext.EnvironmentId, job.Product);
                            throw new TooManyRequestsException(_localizer.GetString("ThrottledByUserQueued"));
                        }

                        // Not logging information here; JobService will log it
                        job.Status = JobStatus.Throttled;
                        reason = ThrottleReason.UserLimit;
                        message = _localizer.GetString("Asynchronous_ThrottledByUser");
                    }
                    else if (counts[job.PartitionKey] >= _maxConcurrency[job.Product]["Environment"])
                    {
                        // Not logging information here; JobService will log it
                        job.Status = JobStatus.Throttled;
                        reason = ThrottleReason.EnvironmentLimit;
                        message = _localizer.GetString("Asynchronous_ThrottledByEnvironment");
                    }
                    break;

                default:
                    throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, "Invalid user experience mode.");
            }

            return (reason, message);
        }

        /// <inheritdoc/>
        public async Task StartNextThrottledJobAsync(JobDocument previousJob, CancellationToken cancellationToken)
        {
            var throttledJobsQuery = new QueryDefinition($@"
select * 
from j 
where j.PartitionKey = @partitionKey 
    and j.Product = 
            {(int)previousJob.Product}
    and j.Status = 
            {(int)JobStatus.Throttled}
order by j.CreateDate");
            throttledJobsQuery.WithParameter("@partitionKey", previousJob.PartitionKey);

            var throttledJobs = await _jobDataAdapter.QueryJobs(throttledJobsQuery, new QueryRequestOptions { PartitionKey = new PartitionKey(previousJob.PartitionKey) }, cancellationToken);

            if (throttledJobs.Any())
            {
                var userIds = throttledJobs.Select(j => j.UserId).Where(id => !string.IsNullOrEmpty(id)).Distinct();
                var statusesToCount = new[] { JobStatus.Pending, JobStatus.Running, JobStatus.Cancelling };
                var counts = await _jobDataAdapter.GetJobCountsAsync(previousJob.Product, previousJob.PartitionKey, statusesToCount, userIds, cancellationToken);

                if (counts[previousJob.PartitionKey] < _maxConcurrency[previousJob.Product]["Environment"])
                {
                    foreach (var jobDocument in throttledJobs)
                    {
                        using var scope = _logger.BeginScope(new Dictionary<string, object>
                        {
                            ["JobId"] = jobDocument.Id,
                            ["EnvironmentId"] = jobDocument.PartitionKey,
                            ["Product"] = jobDocument.Product,
                            ["UserId"] = jobDocument.UserId,
                            ["CommandId"] = jobDocument.CommandId
                        });

                        if (string.IsNullOrEmpty(jobDocument.UserId) || counts[jobDocument.UserId] < _maxConcurrency[previousJob.Product]["User"])
                        {
                            try
                            {
                                await _jobStatusService.MarkJobPending(jobDocument, cancellationToken);
                            }
                            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.PreconditionFailed)
                            {
                                // ETag mismatch, move on to next throttled job
                                continue;
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "An exception occurred updating the next throttled job to pending.");
                                continue;
                            }

                            try
                            {
                                await _backendAdapter.QueueQueryExecutionAsync(jobDocument, cancellationToken);

                                _logger.LogInformation("Started throttled job.", jobDocument.Id);

                                break;
                            }
                            catch (Exception queueExecutionException)
                            {
                                try
                                {
                                    await _jobStatusService.MarkJobFailed(jobDocument, cancellationToken);
                                }
                                catch (Exception markFailedException)
                                {
                                    if (markFailedException is not OperationCanceledException)
                                    {
                                        _logger.LogWarning(markFailedException, "An error occurred marking job failed.");
                                    }
                                    jobDocument.Status = JobStatus.Pending;
                                }

                                _logger.LogError(queueExecutionException, "An exception occurred attempting to start next throttled job.");

                                if (jobDocument.Status == JobStatus.Pending) break;
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// The reason a request was throttled.
    /// </summary>
    public enum ThrottleReason
    {
        /// <summary>
        /// The number of active jobs for the user exceeded the limit.
        /// </summary>
        UserLimit,

        /// <summary>
        /// The number of active jobs for the environment exceeded the limit.
        /// </summary>
        EnvironmentLimit
    }
}

