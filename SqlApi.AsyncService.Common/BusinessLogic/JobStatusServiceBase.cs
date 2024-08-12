using Company.Core.WebService.Contracts.Exceptions;
using Company.Core.WebService.Contracts;
using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.Models;
using Microsoft.Azure.Cosmos;
using Polly.Retry;
using Polly;
using System.Net;
using SqlApi.AsyncService.Common.DataAccess;
using Company.Core.Observability;
using Microsoft.Extensions.Logging;

namespace SqlApi.AsyncService.Common.BusinessLogic
{
    /// <inheritdoc/>
    public class JobStatusServiceBase : IJobStatusServiceBase
    {
        private readonly IJobDataAdapter _jobDataAdapter;
        private readonly ITraceOperationFactory _traceOperationFactory;
        private readonly ILogger _logger;

        private readonly AsyncRetryPolicy _preconditionFailedRetryPolicy = Policy
            .Handle<CosmosException>(ex => ex.StatusCode == HttpStatusCode.PreconditionFailed)
            .RetryAsync(5);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jobDataAdapter"></param>
        /// <param name="traceOperationFactory"></param>
        /// <param name="logger"></param>
        public JobStatusServiceBase(
            IJobDataAdapter jobDataAdapter,
            ITraceOperationFactory traceOperationFactory,
            ILogger<JobStatusServiceBase> logger)
        {
            _jobDataAdapter = jobDataAdapter;
            _traceOperationFactory = traceOperationFactory;
            _logger = logger;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected enum UpdateJobStatusRule
        {
            Update, // Expected state transitions
            UpdateAndWarn, // Unlikely but possible state transitions, potentially indicating a bug
            Conflict, // Expected error cases
            ConflictAndWarn, // Unexpected state transitions
            NoOp // For expected cases where the job may already be the requested status
        }

        protected class UpdateJobStatusRules
        {
            public IReadOnlyDictionary<JobStatus, UpdateJobStatusRule> Rules { get; }
            public bool IsTerminalStatus { get; }

            public UpdateJobStatusRules(
                UpdateJobStatusRule fromThrottledRule,
                UpdateJobStatusRule fromPendingRule,
                UpdateJobStatusRule fromRunningRule,
                UpdateJobStatusRule fromCompletedRule,
                UpdateJobStatusRule fromFailedRule,
                UpdateJobStatusRule fromCancellingRule,
                UpdateJobStatusRule fromCancelledRule,
                bool isTerminalStatus)
            {
                Rules = new Dictionary<JobStatus, UpdateJobStatusRule>
                {
                    { JobStatus.Throttled, fromThrottledRule },
                    { JobStatus.Pending, fromPendingRule },
                    { JobStatus.Running, fromRunningRule },
                    { JobStatus.Completed, fromCompletedRule },
                    { JobStatus.Failed, fromFailedRule },
                    { JobStatus.Cancelling, fromCancellingRule },
                    { JobStatus.Cancelled, fromCancelledRule }
                };

                IsTerminalStatus = isTerminalStatus;
            }
        }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        // See Job_state.png in Solution Items

        private readonly UpdateJobStatusRules _markPendingRules = new(
            fromThrottledRule: UpdateJobStatusRule.Update, // The typical transition
            fromPendingRule: UpdateJobStatusRule.Update, // Job may be retried by ResiliencyFunctions if it never got picked up
            fromRunningRule: UpdateJobStatusRule.Update, // Job may be reset to Pending from Running by ResiliencyFunctions if the heartbeat has stopped
            fromCompletedRule: UpdateJobStatusRule.ConflictAndWarn,
            fromFailedRule: UpdateJobStatusRule.ConflictAndWarn,
            fromCancellingRule: UpdateJobStatusRule.ConflictAndWarn,
            fromCancelledRule: UpdateJobStatusRule.ConflictAndWarn,
            isTerminalStatus: false);

        private readonly UpdateJobStatusRules _markRunningRules = new(
            fromThrottledRule: UpdateJobStatusRule.ConflictAndWarn,
            fromPendingRule: UpdateJobStatusRule.Update, // The expected transition
            fromRunningRule: UpdateJobStatusRule.ConflictAndWarn,
            fromCompletedRule: UpdateJobStatusRule.ConflictAndWarn,
            fromFailedRule: UpdateJobStatusRule.ConflictAndWarn,
            fromCancellingRule: UpdateJobStatusRule.Conflict, // Possible if the front-end cancels before the back-end picks up the job. Back-end should mark cancelled instead.
            fromCancelledRule: UpdateJobStatusRule.ConflictAndWarn,
            isTerminalStatus: false);

        private readonly UpdateJobStatusRules _markCancellingRules = new(
            fromThrottledRule: UpdateJobStatusRule.Update,
            fromPendingRule: UpdateJobStatusRule.Update,
            fromRunningRule: UpdateJobStatusRule.Update,
            fromCompletedRule: UpdateJobStatusRule.Conflict,
            fromFailedRule: UpdateJobStatusRule.Conflict,
            fromCancellingRule: UpdateJobStatusRule.NoOp,
            fromCancelledRule: UpdateJobStatusRule.Conflict,
            isTerminalStatus: false);

        private readonly UpdateJobStatusRules _markCompletedRules = new(
            fromThrottledRule: UpdateJobStatusRule.ConflictAndWarn,
            fromPendingRule: UpdateJobStatusRule.UpdateAndWarn, // Possible if the job was updated to pending b/c of an expired heartbeat but ended up completing in the back-end.  Indicates a likely problem w/ the heartbeat logic.
            fromRunningRule: UpdateJobStatusRule.Update, // The expected transition
            fromCompletedRule: UpdateJobStatusRule.ConflictAndWarn,
            fromFailedRule: UpdateJobStatusRule.ConflictAndWarn,
            fromCancellingRule: UpdateJobStatusRule.Update, // Possible for the job to complete after cancellation has been requested.
            fromCancelledRule: UpdateJobStatusRule.UpdateAndWarn, // Possible if the job was updated to cancelled b/c of an expired heartbeat but ended up completing in the back-end.  Indicates a likely problem w/ the heartbeat logic.
            isTerminalStatus: true);

        private readonly UpdateJobStatusRules _markFailedRules = new(
            fromThrottledRule: UpdateJobStatusRule.ConflictAndWarn,
            fromPendingRule: UpdateJobStatusRule.Update, // Possible if we are unable to send the job to the back-end
            fromRunningRule: UpdateJobStatusRule.Update, // The expected transition
            fromCompletedRule: UpdateJobStatusRule.ConflictAndWarn,
            fromFailedRule: UpdateJobStatusRule.ConflictAndWarn,
            fromCancellingRule: UpdateJobStatusRule.Update, // Possible for the job to complete after cancellation has been requested.
            fromCancelledRule: UpdateJobStatusRule.UpdateAndWarn, // Possible if the job was updated to cancelled b/c of an expired heartbeat but ended up completing in the back-end.  Indicates a likely problem w/ the heartbeat logic.
            isTerminalStatus: true);

        private readonly UpdateJobStatusRules _markCancelledRules = new(
            fromThrottledRule: UpdateJobStatusRule.ConflictAndWarn,
            fromPendingRule: UpdateJobStatusRule.Update, // Can be updated by resiliency to support passive cancellation.
            fromRunningRule: UpdateJobStatusRule.Update, // Can be updated by resiliency to support passive cancellation.
            fromCompletedRule: UpdateJobStatusRule.ConflictAndWarn,
            fromFailedRule: UpdateJobStatusRule.ConflictAndWarn,
            fromCancellingRule: UpdateJobStatusRule.Update,
            fromCancelledRule: UpdateJobStatusRule.NoOp, // Resiliency and back-end could both attempt this update
            isTerminalStatus: true);

        /// <inheritdoc/>
        public async Task MarkJobPending(JobDocument jobDocument, CancellationToken cancellationToken)
        {
            await UpdateJobStatusInner(jobDocument, null, JobStatus.Pending, _markPendingRules, null, null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task MarkJobRunning(string id, string requestId, IRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(requestId))
            {
                throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, $"The {nameof(requestId)} parameter is required.");
            }

            await UpdateJobStatus(id, requestId, JobStatus.Running, _markRunningRules, null, requestContext, false, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task MarkJobCancelling(string id, IRequestContext requestContext, bool isSupportal, CancellationToken cancellationToken)
        {
            await UpdateJobStatus(id, null, JobStatus.Cancelling, _markCancellingRules, null, requestContext, isSupportal, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task MarkJobCancelling(JobDocument jobDocument, CancellationToken cancellationToken)
        {
            await UpdateJobStatusInner(jobDocument, null, JobStatus.Cancelling, _markCancellingRules, null, null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task MarkJobCompleted(string id, string requestId, JobMetrics jobMetrics, IRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(requestId))
            {
                throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, $"The {nameof(requestId)} parameter is required.");
            }

            await UpdateJobStatus(id, requestId, JobStatus.Completed, _markCompletedRules, jobMetrics, requestContext, false, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task MarkJobFailed(string id, string requestId, MarkFailedRequest request, IRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(requestId))
            {
                throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, $"The {nameof(requestId)} parameter is required.");
            }

            var jobDocument = await UpdateJobStatus(id, requestId, JobStatus.Failed, _markFailedRules, request, requestContext, false, cancellationToken);

            using var scope = _logger.BeginScope(new Dictionary<string, object>
            {
                ["JobId"] = id,
                ["RequestId"] = requestId,
                ["CommandId"] = jobDocument.CommandId,
                ["Audience"] = jobDocument.Audience
            });

            var logLevel = !string.IsNullOrEmpty(jobDocument?.Audience) && jobDocument.Audience.Contains("qry-defin") ? LogLevel.Error : LogLevel.Information;
            _logger.Log(logLevel, "Job failed: " + request?.ErrorMessage);
        }

        /// <inheritdoc/>
        public async Task MarkJobFailed(JobDocument jobDocument, CancellationToken cancellationToken)
        {
            await UpdateJobStatusInner(jobDocument, null, JobStatus.Failed, _markFailedRules, null, null, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task MarkJobCancelled(string id, string requestId, JobMetrics jobMetrics, IRequestContext requestContext, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(requestId))
            {
                throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, $"The {nameof(requestId)} parameter is required.");
            }

            await UpdateJobStatus(id, requestId, JobStatus.Cancelled, _markCancelledRules, jobMetrics, requestContext, false, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task MarkJobCancelled(JobDocument jobDocument, CancellationToken cancellationToken)
        {
            await UpdateJobStatusInner(jobDocument, null, JobStatus.Cancelled, _markCancelledRules, null, null, cancellationToken);
        }

        private async Task<JobDocument> UpdateJobStatus(
            string id,
            string requestId,
            JobStatus targetJobStatus,
            UpdateJobStatusRules rules,
            JobMetrics jobMetrics,
            IRequestContext requestContext,
            bool isSupportal,
            CancellationToken cancellationToken)
        {
            return await _preconditionFailedRetryPolicy.ExecuteAsync(ct => UpdateJobStatusInner(id, requestId, targetJobStatus, rules, jobMetrics, requestContext, isSupportal, ct), cancellationToken);
        }

        private async Task<JobDocument> UpdateJobStatusInner(
            string id,
            string requestId,
            JobStatus targetJobStatus,
            UpdateJobStatusRules rules,
            JobMetrics jobMetrics,
            IRequestContext requestContext,
            bool isSupportal,
            CancellationToken cancellationToken)
        {
            using var scope = _logger.BeginScope(new Dictionary<string, object>
            {
                ["JobId"] = id,
                ["RequestId"] = requestId
            });

            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, $"The {nameof(id)} parameter is required.");
            }
            if (!Guid.TryParse(id, out Guid _))
            {
                throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, $"Invalid {nameof(id)}, please provide a valid Guid.");
            }

            var jobDocument = await _jobDataAdapter.GetJob(id, requestContext.EnvironmentId, cancellationToken) ?? throw new RecordNotFoundV2Exception();

            if (!isSupportal)
            {
                AuthorizationHelper.AuthorizeJobAccess(jobDocument, requestContext);
            }

            await UpdateJobStatusInner(jobDocument, requestId, targetJobStatus, rules, jobMetrics, requestContext, cancellationToken);

            return jobDocument;
        }

        private async Task UpdateJobStatusInner(
            JobDocument jobDocument,
            string requestId,
            JobStatus targetJobStatus,
            UpdateJobStatusRules rules,
            JobMetrics jobMetrics,
            IRequestContext requestContext,
            CancellationToken cancellationToken)
        {
            const string unexpectedTransitionWarning = "Unexpected job status transition request from {FromStatus} to {ToStatus}.";
            var currentStatusRule = rules.Rules[jobDocument.Status];
            if (currentStatusRule == UpdateJobStatusRule.NoOp)
            {
                return;
            }

            var retryPolicy = Policy
                .Handle<ConflictV2Exception>((ex) =>
                {
                    if (ex.Values?.TryGetValue("CurrentStatus", out object v) ?? false)
                    {
                        return v.ToString() == JobStatus.Throttled.ToString();
                    }

                    return false;
                })
                .WaitAndRetryAsync(3,
                    retryCount => TimeSpan.FromMilliseconds(200 * retryCount),
                    async (ex, t) =>
                    {
                        jobDocument = await _jobDataAdapter.GetJob(jobDocument.Id, requestContext.EnvironmentId, cancellationToken);
                        currentStatusRule = rules.Rules[jobDocument.Status];
                    });

            try
            {
                await retryPolicy.ExecuteAsync(() =>
                {
                    CommonExceptions.ValidateRequestId(requestId, jobDocument, _logger);

                    if (currentStatusRule == UpdateJobStatusRule.Conflict || currentStatusRule == UpdateJobStatusRule.ConflictAndWarn)
                    {
                        CommonExceptions.ThrowUnexpectedStatusConflict(jobDocument.Status, targetJobStatus);
                    }

                    return Task.CompletedTask;
                });

                if (currentStatusRule == UpdateJobStatusRule.UpdateAndWarn)
                {
                    _logger.LogWarning(unexpectedTransitionWarning, jobDocument.Status, targetJobStatus);
                }
            }
            catch (ConflictV2Exception)
            {
                if (currentStatusRule == UpdateJobStatusRule.ConflictAndWarn)
                {
                    _logger.LogWarning(unexpectedTransitionWarning, jobDocument.Status, targetJobStatus);
                }

                throw;
            }

            AuditChange(jobDocument, requestContext);
            jobDocument.Status = targetJobStatus;
            jobDocument.Heartbeat = DateTime.UtcNow;
            jobDocument.Metrics = jobMetrics;

            if (targetJobStatus == JobStatus.Running)
            {
                jobDocument.RunDate = DateTime.UtcNow;
            }
            else if (rules.IsTerminalStatus)
            {
                jobDocument.EndDate = DateTime.UtcNow;
            }

            if (jobMetrics is MarkFailedRequest markFailedRequest)
            {
                jobDocument.ErrorMessage = markFailedRequest?.ErrorMessage;
            }

            await _jobDataAdapter.UpsertJob(jobDocument, cancellationToken);

            try
            {
                if (targetJobStatus == JobStatus.Completed)
                {
                    using var traceOperation = _traceOperationFactory.StartOperation("CompletedJob", null);
                    traceOperation.Tag("JobId", jobDocument.Id);
                    traceOperation.Tag(nameof(jobDocument.CommandId), jobDocument.CommandId);
                    traceOperation.Tag("EnvironmentId", jobDocument.PartitionKey);
                    traceOperation.Tag(nameof(jobDocument.Audience), jobDocument.Audience);
                    traceOperation.Tag(nameof(jobDocument.CommandService), jobDocument.CommandService ?? jobDocument.Audience);
                    traceOperation.Tag(nameof(jobDocument.Product), jobDocument.Product.ToString());
                    traceOperation.Tag("Status", targetJobStatus.ToString());
                    traceOperation.Tag(nameof(jobDocument.Retries), jobDocument.Retries);

                    if (jobMetrics != null)
                    {
                        if (jobMetrics.Operations != null)
                        {
                            foreach (var jobOperation in jobMetrics.Operations)
                            {
                                traceOperation.Tag($"Metric.{jobOperation.Key}", jobOperation.Value);
                            }
                        }
                        if (jobMetrics.DataSets != null)
                        {
                            traceOperation.Tag("ValueCount", jobMetrics.DataSets.Sum(dataSet => dataSet.Rows * dataSet.Columns));
                            traceOperation.Tag("BlobBytes", jobMetrics.DataSets.Sum(dataSet => dataSet.BlobBytes));
                        }
                    }

                    traceOperation.Tag("TotalSeconds", (jobDocument.EndDate.Value - jobDocument.CreateDate).TotalSeconds);

                    var runDate = jobDocument.RunDate ?? jobDocument.CreateDate;

                    traceOperation.Tag("ExecutionSeconds", (jobDocument.EndDate.Value - runDate).TotalSeconds);

                    var (wasThrottled, firstPending, lastPending) = GetHistoryInfo(jobDocument);

                    if (wasThrottled)
                    {
                        traceOperation.Tag("ThrottledSeconds", (firstPending - jobDocument.CreateDate).TotalSeconds);
                    }
                    if (jobDocument.Retries > 0)
                    {
                        traceOperation.Tag("RetrySeconds", (lastPending - firstPending).TotalSeconds);
                    }
                    traceOperation.Tag("PendingSeconds", (runDate - lastPending).TotalSeconds);

                    traceOperation.Complete();
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception occurred writing to observability");
            }

            try
            {
                await PostUpdate(jobDocument, rules, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Exception occurred during post job status update");
            }
        }

        private static (bool WasThrottled, DateTime FirstPending, DateTime LastPending) GetHistoryInfo(JobDocument jobDocument)
        {
            var wasThrottled = false;
            var firstPending = jobDocument.CreateDate;
            var lastPending = jobDocument.CreateDate;

            if (jobDocument.History != null)
            {
                var firstEvent = jobDocument.History.FirstOrDefault();

                if (firstEvent != null && firstEvent.PreviousStatus == JobStatus.Throttled)
                {
                    wasThrottled = true;
                    firstPending = firstEvent.DateChanged;
                }

                var lastUpdateFromPendingIndex = jobDocument.History.FindLastIndex(jobEvent => jobEvent.PreviousStatus == JobStatus.Pending);
                if (lastUpdateFromPendingIndex >= 1)
                {
                    var lastUpdateToPending = jobDocument.History[lastUpdateFromPendingIndex - 1];
                    lastPending = lastUpdateToPending.DateChanged;
                }
            }

            return (wasThrottled, firstPending, lastPending);
        }

        private static void AuditChange(JobDocument job, IRequestContext requestContext)
        {
            (job.History ??= new List<JobEvent>()).Add(new JobEvent
            {
                DateChanged = DateTime.UtcNow,
                ChangedBy = requestContext?.AuthenticationUserId,
                Service = requestContext != null ? requestContext.TrustedCallerClientName : "nsa-async",
                PreviousStatus = job.Status
            });
        }

        /// <summary>
        /// Logic to perform after a status change has been performed
        /// </summary>
        /// <param name="jobDocument"></param>
        /// <param name="rules"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected virtual Task PostUpdate(JobDocument jobDocument, UpdateJobStatusRules rules, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
