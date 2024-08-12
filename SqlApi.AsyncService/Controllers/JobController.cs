
using Company.Core.WebService.AspNetCore.Authorization;
using Company.Core.WebService.AspNetCore.Filters;
using Company.Core.WebService.Contracts.Exceptions;
using SqlApi.AsyncService.BusinessLogic;
using SqlApi.AsyncService.Common;
using SqlApi.AsyncService.Common.Models;
using Company.Swagger.AspNetCore.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
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
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        /// <summary>
        /// Constructs the JobController.
        /// </summary>
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        /// <summary>
        /// Create job
        /// </summary>
        /// <remarks>
        /// Creates and executes the specified job
        /// </remarks>
        [HttpPost("jobs")]
        [Authorize(AuthenticationSchemes = "SAS")]
        [ServiceAuthorizationScopeFilter(AuthorizationHelper.ConsumerScope)]
        [SwaggerOperation(
            OperationId = "CreateJob",
            Summary = "Create job",
            Description = "Creates and executes the specified job"
            )]
        [SwaggerResponse(200)]
        public async Task<CreateJobResponse> CreateJob([FromBody, Required] CreateJobRequest createJobRequest, CancellationToken cancellationToken)
        {
            return await _jobService.CreateJob(createJobRequest, cancellationToken);
        }

        /// <summary>
        /// Get job
        /// </summary>
        [HttpGet("jobs/{id}")]
        [Authorize(AuthenticationSchemes = "BBID,SAS")]
        [ServiceAuthorizationScopeFilter(AuthorizationHelper.ConsumerScope)]
        [SwaggerOperation(
            OperationId = "GetJob",
            Summary = "Get job",
            Description = "Gets information about the specified job"
            )]
        [SwaggerResponse(200)]
        public async Task<Job> GetJob(string id, [FromQuery(Name = "include_read_url")] IncludeReadUrl includeReadUrl, [FromQuery(Name = "content_disposition")] BlobContentDisposition contentDisposition, CancellationToken cancellationToken)
        {
            return await _jobService.GetJob(id, null, includeReadUrl, contentDisposition, cancellationToken);
        }

        /// <summary>
        /// Get job for back-end
        /// </summary>
        [HttpGet("jobs/{id}/backend")]
        [Authorize(AuthenticationSchemes = "SAS")]
        [ServiceAuthorizationScopeFilter(AuthorizationHelper.BackendScope)]
        [SwaggerOperation(
            OperationId = "GetJobBackend",
            Summary = "Get job",
            Description = "Gets information about the specified job"
            )]
        [SwaggerResponse(200)]
        public async Task<Job> GetJob(string id, [FromQuery(Name = "request_id")] string requestId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(requestId))
            {
                throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, $"The {nameof(requestId)} parameter is required.");
            }

            return await _jobService.GetJob(id, requestId, IncludeReadUrl.Never, default, cancellationToken);
        }

        /// <summary>
        /// Get job blob write uri
        /// </summary>
        /// <remarks>
        /// Get an additional append blob write uri for the given job
        /// </remarks>
        [HttpGet("jobs/{id}/blobs/{sequence}")]
        [Authorize(AuthenticationSchemes = "SAS")]
        [ServiceAuthorizationScopeFilter(AuthorizationHelper.BackendScope)]
        [SwaggerOperation(
            OperationId = "GetAppendBlobWriteUri",
            Summary = "Get append blob write uri",
            Description = "Get append blob write uri for the given job and dataset sequence"
            )]
        [SwaggerResponse(200)]
        public async Task<string> GetAppendBlobWriteUriAsync(string id, int sequence, string requestId, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, $"The {nameof(id)} parameter is required.");
            }

            if (!Guid.TryParse(id, out Guid parsedId))
            {
                throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, $"Invalid {nameof(id)}, please provide a valid Guid.");
            }

            if (string.IsNullOrWhiteSpace(requestId))
            {
                throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, $"The {nameof(requestId)} parameter is required.");
            }

            return await _jobService.GetBlobWriteUriAsync(parsedId.ToString(), sequence, requestId, cancellationToken);
        }
    }
}
