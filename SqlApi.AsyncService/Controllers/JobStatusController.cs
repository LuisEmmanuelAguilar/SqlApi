using Company.Core.WebService.AspNetCore.Authorization;
using Company.Core.WebService.AspNetCore.Filters;
using Company.Core.WebService.Contracts;
using SqlApi.AsyncService.Common;
using SqlApi.AsyncService.Common.BusinessLogic;
using SqlApi.AsyncService.Common.Models;
using Company.Swagger.AspNetCore.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace SqlApi.AsyncService.Controllers
{
    /// <summary>
    /// Endpoints for interacting with query jobs.
    /// </summary>
    [BypassCompanyIdHasAtLeastOnePermissionFilter]
    [ExcludeEndpointFromSKYAPI("Internal endpoints")]
    [EnvironmentIdContextFilter]
    [SwaggerResponse(401)]
    [SwaggerResponse(403)]
    public class JobStatusController : ControllerBase
    {
        private readonly IJobStatusService _jobStatusService;
        private readonly IRequestContext _requestContext;

        /// <summary>
        /// Constructs the JobController.
        /// </summary>
        public JobStatusController(
            IJobStatusService jobStatusService,
            IRequestContext requestContext)
        {
            _jobStatusService = jobStatusService;
            _requestContext = requestContext;
        }

        /// <summary>
        /// Mark a job running.
        /// </summary>
        /// <param name="id">The job id</param>
        /// <param name="requestId">The request id</param>
        /// <param name="cancellationToken"></param>
        /// <returns>SAS URL for writing results to a blob</returns>
        [HttpPost("jobs/{id}/running")]
        [Authorize(AuthenticationSchemes = "SAS")]
        [ServiceAuthorizationScopeFilter(AuthorizationHelper.BackendScope)]
        [SwaggerOperation(
            OperationId = "MarkJobRunning",
            Summary = "Mark job running",
            Description = "Updates the job status to running"
            )]
        [SwaggerResponse(200)]
        public async Task MarkJobRunning(string id, string requestId, CancellationToken cancellationToken)
        {
            await _jobStatusService.MarkJobRunning(id, requestId, _requestContext, cancellationToken);
        }

        /// <summary>
        /// Cancel a job.
        /// </summary>
        /// <param name="id">The job id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("jobs/{id}/cancel")]
        [Authorize(AuthenticationSchemes = "BBID,SAS")]
        [ServiceAuthorizationScopeFilter(AuthorizationHelper.ConsumerScope)]
        [SwaggerOperation(
            OperationId = "CancelJob",
            Summary = "Cancel a job",
            Description = "Updates the job status to cancelling"
            )]
        [SwaggerResponse(200)]
        public async Task CancelJob(string id, CancellationToken cancellationToken)
        {
            await _jobStatusService.MarkJobCancelling(id, _requestContext, false, cancellationToken);
        }

        /// <summary>
        /// Mark a job completed.
        /// </summary>
        /// <param name="id">The job id</param>
        /// <param name="requestId">The request id</param>
        /// <param name="jobMetrics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>SAS URL for writing results to a blob</returns>
        [HttpPost("jobs/{id}/completed")]
        [Authorize(AuthenticationSchemes = "SAS")]
        [ServiceAuthorizationScopeFilter(AuthorizationHelper.BackendScope)]
        [SwaggerOperation(
            OperationId = "MarkJobCompleted",
            Summary = "Mark job completed",
            Description = "Updates the job status to completed"
            )]
        [SwaggerResponse(200)]
        public async Task MarkJobCompleted(string id, string requestId, [FromBody] JobMetrics jobMetrics, CancellationToken cancellationToken)
        {
            await _jobStatusService.MarkJobCompleted(id, requestId, jobMetrics, _requestContext, cancellationToken);
        }

        /// <summary>
        /// Mark a job failed.
        /// </summary>
        /// <param name="id">The job id</param>
        /// <param name="requestId">The request id</param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>SAS URL for writing results to a blob</returns>
        [HttpPost("jobs/{id}/failed")]
        [Authorize(AuthenticationSchemes = "SAS")]
        [ServiceAuthorizationScopeFilter(AuthorizationHelper.BackendScope)]
        [SwaggerOperation(
            OperationId = "MarkJobFailed",
            Summary = "Mark job failed",
            Description = "Updates the job status to failed"
            )]
        [SwaggerResponse(200)]
        public async Task MarkJobFailed(string id, string requestId, [FromBody] MarkFailedRequest request, CancellationToken cancellationToken)
        {
            await _jobStatusService.MarkJobFailed(id, requestId, request, _requestContext, cancellationToken);
        }

        /// <summary>
        /// Mark a job cancelled.
        /// </summary>
        /// <param name="id">The job id</param>
        /// <param name="requestId">The request id</param>
        /// <param name="jobMetrics"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>SAS URL for writing results to a blob</returns>
        [HttpPost("jobs/{id}/cancelled")]
        [Authorize(AuthenticationSchemes = "SAS")]
        [ServiceAuthorizationScopeFilter(AuthorizationHelper.BackendScope)]
        [SwaggerOperation(
            OperationId = "MarkJobCancelled",
            Summary = "Mark job cancelled",
            Description = "Updates the job status to cancelled"
            )]
        [SwaggerResponse(200)]
        public async Task MarkJobCancelled(string id, string requestId, [FromBody] JobMetrics jobMetrics, CancellationToken cancellationToken)
        {
            await _jobStatusService.MarkJobCancelled(id, requestId, jobMetrics, _requestContext, cancellationToken);
        }
    }
}
