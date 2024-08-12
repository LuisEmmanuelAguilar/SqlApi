using Company.Core.Observability;
using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.DataAccess;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Text.Json;

namespace SqlApi.AsyncService.Common.BusinessLogic
{
    /// <summary>
    /// The reason this additional interface/class is needed in addition to (I)JobStatusServiceBase is b/c
    /// there's a circular dependency between JobStatusService and JobThrottlingService:
    /// - When a job is updated to a terminal status, the next throttled job should get started.
    /// - To start the next throttled job, the job's status gets updated.
    /// 
    /// In order to resolve the circular dependency, JobStatusServiceBase does not handle the call to
    /// JobThrottlingService - that call is now added by this class by overriding PostUpdate.  Most places
    /// that need to make job status updates should inject IJobStatusService.  The exception is
    /// JobThrottlingService, which will inject IJobStatusServiceBase in order to avoid the circular dependency.
    /// </summary>
    public interface IJobStatusService : IJobStatusServiceBase { }

    /// <inheritdoc/>
    public class JobStatusService : JobStatusServiceBase, IJobStatusService
    {
        private readonly IJobThrottlingService _jobThrottlingService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jobThrottlingService"></param>
        /// <param name="jobDataAdapter"></param>
        /// <param name="traceOperationFactory"></param>
        /// <param name="logger"></param>
        public JobStatusService(
            IJobThrottlingService jobThrottlingService,
            IJobDataAdapter jobDataAdapter,
            ITraceOperationFactory traceOperationFactory,
            ILogger<JobStatusServiceBase> logger) : base(jobDataAdapter, traceOperationFactory, logger)
        {
            _jobThrottlingService = jobThrottlingService;
        }

        /// <inheritdoc/>
        protected override async Task PostUpdate(JobDocument jobDocument, UpdateJobStatusRules rules, CancellationToken cancellationToken)
        {
            if (rules.IsTerminalStatus)
            {
                await _jobThrottlingService.StartNextThrottledJobAsync(jobDocument, cancellationToken);
            }
        }
    }
}
