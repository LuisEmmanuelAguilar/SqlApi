using System.Data;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Text;

namespace SqlApi.AsyncService.BusinessLogic
{
    public class SupportalIJobService
    {
    }
}
using SqlApi.AsyncService.Common.Models;
using System.Threading.Tasks;
using System.Threading;
using Company.Core.WebService.Contracts.Exceptions;
using SqlApi.AsyncService.Common.DataAccess;
using Company.Core.WebService.Contracts;
using System.Collections.Generic;
using SqlApi.AsyncService.Common.DataAccess.Models;
using System;
using SqlApi.AsyncService.Common.BusinessLogic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SqlApi.AsyncService.BusinessLogic
{
    /// <summary>
    /// Supportal job service
    /// </summary>
    public class SupportalJobService
    {
        private readonly IJobDataAdapter _jobDataAdapter;
        private readonly IJobService _jobService;
        private readonly IJobStatusService _jobStatusService;
        private readonly IRequestContext _requestContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jobDataAdapter"></param>
        /// <param name="jobService"></param>
        /// <param name="jobStatusService"></param>
        /// <param name="requestContext"></param>
        public SupportalJobService(IJobDataAdapter jobDataAdapter, IJobService jobService, IJobStatusService jobStatusService, IRequestContext requestContext)
        {
            _jobDataAdapter = jobDataAdapter;
            _jobService = jobService;
            _jobStatusService = jobStatusService;
            _requestContext = requestContext;
        }

        private static void AddRequestFilter(
            string parameterName,
            object parameterValue,
            StringBuilder sb,
            List<(string Name, object Value)> parameters)
        {
            if (parameterValue is not null)
            {
                sb.Append($" and c.{parameterName} = @{parameterName}");
                parameters.Add(($"@{parameterName}", parameterValue));
            }
        }

        /// <summary>
        /// Get a list of jobs
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SupportalJob>> GetJobs(GetJobsRequest request, CancellationToken cancellationToken)
        {
            var sb = new StringBuilder("select * from c where c.PartitionKey = @environmentId");
            var parameters = new List<(string Name, object Value)>
            {
                ("@environmentId", _requestContext.EnvironmentId)
            };

            AddRequestFilter(nameof(request.Audience), request.Audience, sb, parameters);
            AddRequestFilter(nameof(request.Product), (int?)request.Product, sb, parameters);
            AddRequestFilter(nameof(request.UserId), request.UserId, sb, parameters);

            if (request.Statuses != null)
            {
                sb.Append($" and c.Status in({string.Join(',', request.Statuses.Select(status => (int)status))})");
            }

            if (request.CreateDate.HasValue)
            {
                sb.Append($" and c.CreateDate between @startDate and @endDate");
                parameters.Add(("@startDate", request.CreateDate.Value.Date));
                parameters.Add(("@endDate", request.CreateDate.Value.Date.AddDays(1).AddMilliseconds(-1)));
            }
            else if (request.RelativeFromCreateDate is not null)
            {
                var match = Regex.Match(request.RelativeFromCreateDate, "(\\d+)([mhd])")
                    ?? throw new InvalidInputV2Exception<ErrorCode>(ErrorCode.InvalidRelativeDateFilter, "Expected syntax [n][u], where [n] is an integer and [u] is \"m\" (minutes), \"h\" (hours), or \"d\" (days)");

                var quantity = int.Parse(match.Groups[1].Value);
                var unit = match.Groups[2].Value;

                var fromCreateDate = DateTime.UtcNow.Add(new TimeSpan(unit == "d" ? -quantity : 0, unit == "h" ? -quantity : 0, unit == "m" ? -quantity : 0, 0));

                sb.Append($" and c.CreateDate >= @startDate");
                parameters.Add(("@startDate", fromCreateDate));
            }

            var query = new Microsoft.Azure.Cosmos.QueryDefinition(sb.ToString());

            foreach (var (parameterName, parameterValue) in parameters)
            {
                query.WithParameter(parameterName, parameterValue);
            }

            var options = new Microsoft.Azure.Cosmos.QueryRequestOptions
            {
                PartitionKey = new Microsoft.Azure.Cosmos.PartitionKey(_requestContext.EnvironmentId)
            };

            var jobDocuments = await _jobDataAdapter.QueryJobs(query, options, cancellationToken);

            return jobDocuments
                .Select(async jobDocument => await MapJobDocumentToSupportalJob(jobDocument, default, default, cancellationToken))
                .Select(jobTask => jobTask.Result);
        }

        /// <summary>
        /// Get a job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeReadUrl"></param>
        /// <param name="contentDisposition"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="RecordNotFoundV2Exception"></exception>
        public async Task<SupportalJob> GetJob(string id, IncludeReadUrl includeReadUrl, BlobContentDisposition contentDisposition, CancellationToken cancellationToken)
        {
            var jobDocument = await _jobDataAdapter.GetJob(id, _requestContext.EnvironmentId, cancellationToken) ?? throw new RecordNotFoundV2Exception("Job record not found");

            return await MapJobDocumentToSupportalJob(jobDocument, includeReadUrl, contentDisposition, cancellationToken);
        }

        private async Task<SupportalJob> MapJobDocumentToSupportalJob(JobDocument jobDocument, IncludeReadUrl includeReadUrl, BlobContentDisposition contentDisposition, CancellationToken cancellationToken)
        {
            var job = await _jobService.MapJob<SupportalJob>(jobDocument, includeReadUrl, contentDisposition, cancellationToken);

            job.Heartbeat = jobDocument.Heartbeat;
            job.UXHeartbeat = jobDocument.UXHeartbeat;
            job.Retries = jobDocument.Retries;
            job.Metrics = jobDocument.Metrics;

            // The history stored on the JobDocument is difficult to follow as it only captures updates (it doesn't include the job creation)
            // and each update only stores the previous status, not the new status (that can be inferred only by looking at the next status
            // in the history or the current job status for the last event.
            // For supportal purposes, we'll map to a more useful format that includes an event for the original insert and has both
            // previous and new status on each update.
            job.History = new List<SupportalJobEvent>();

            JobEvent previousEvent = null;
            DateTime? previousDateTime = null;

            if (jobDocument.History is not null)
            {
                foreach (var jobEvent in jobDocument.History)
                {
                    // For the first event in the history, we won't have a previous event.  The item we create for that will represent the creation of the job.
                    // After that, each event we add really represents the previous event.
                    // The last event we pull will get handled by the final Add below the loop.
                    job.History.Add(new SupportalJobEvent
                    {
                        PreviousStatus = previousEvent?.PreviousStatus,
                        NewStatus = jobEvent.PreviousStatus,
                        DateChanged = previousEvent?.DateChanged ?? jobDocument.CreateDate,
                        DurationAtPreviousStatus = previousEvent?.DateChanged - previousDateTime,
                        ChangedBy = previousEvent == null ? jobDocument.UserId : previousEvent.ChangedBy,
                        Service = previousEvent == null ? jobDocument.Audience : previousEvent.Service
                    });

                    previousDateTime = previousEvent?.DateChanged ?? jobDocument.CreateDate;
                    previousEvent = jobEvent;
                }
            }

            // Add the last event in the history.  If there is no history on the job (previousEvent will be null), this event represents the creation of the job,
            // which also matches the current state.
            job.History.Add(new SupportalJobEvent
            {
                PreviousStatus = previousEvent?.PreviousStatus,
                NewStatus = jobDocument.Status,
                DateChanged = previousEvent?.DateChanged ?? jobDocument.CreateDate,
                DurationAtPreviousStatus = previousEvent == null ? DateTime.UtcNow - jobDocument.CreateDate : previousEvent?.DateChanged - previousDateTime,
                ChangedBy = previousEvent == null ? jobDocument.UserId : previousEvent.ChangedBy,
                Service = previousEvent == null ? jobDocument.Audience : previousEvent.Service
            });

            return job;
        }

        /// <summary>
        /// Cancel a job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CancelJob(string id, CancellationToken cancellationToken)
        {
            await _jobStatusService.MarkJobCancelling(id, _requestContext, true, cancellationToken);
        }
    }
}
