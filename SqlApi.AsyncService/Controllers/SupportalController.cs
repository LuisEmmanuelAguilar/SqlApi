using Company.Core.WebService.AspNetCore.Filters;
using SqlApi.AsyncService.Authorization;
using SqlApi.AsyncService.BusinessLogic;
using SqlApi.AsyncService.Common.Models;
using Company.Swagger.AspNetCore.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace SqlApi.AsyncService.Controllers
{
    /// <summary>
    /// Supportal endpoints
    /// </summary>
    [Route("supportal")]
    [SupportalEndpoint(AuthorizationPolicies.SupportalPolicy)]
    [ApiController]
    [EnvironmentIdContextFilter(true)]
    [ExcludeFromCodeCoverage]
    public class SupportalController : ControllerBase
    {
        private readonly SupportalJobService _jobService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="jobService"></param>
        public SupportalController(SupportalJobService jobService)
        {
            _jobService = jobService;
        }

        /// <summary>
        /// Get a list of jobs
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("jobs")]
        public async Task<IEnumerable<SupportalJob>> GetJobs([FromRoute(Name = "")] GetJobsRequest request, CancellationToken cancellationToken)
        {
            return await _jobService.GetJobs(request, cancellationToken);
        }

        /// <summary>
        /// Get a job
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeReadUrl"></param>
        /// <param name="contentDisposition"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("jobs/{id}")]
        public async Task<SupportalJob> GetJob(string id, [FromQuery(Name = "include_read_url")] IncludeReadUrl includeReadUrl, [FromQuery(Name = "content_disposition")] BlobContentDisposition contentDisposition, CancellationToken cancellationToken)
        {
            return await _jobService.GetJob(id, includeReadUrl, contentDisposition, cancellationToken);
        }

        /// <summary>
        /// Cancel a job.
        /// </summary>
        /// <param name="id">The job id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("jobs/{id}/cancel")]
        public async Task CancelJob(string id, CancellationToken cancellationToken)
        {
            await _jobService.CancelJob(id, cancellationToken);
        }

    }
}
