using Company.Core.WebService.Contracts;
using SqlApi.AsyncService.Common.DataAccess.Models;
using System.Text.Json;

namespace SqlApi.AsyncService.Common.BusinessLogic
{
    /// <summary>
    /// Service providing behavior related to throttling jobs
    /// </summary>
    public interface IJobThrottlingService
    {
        /// <summary>
        /// Start the next throttled job when a job completes
        /// </summary>
        /// <param name="previousJob">The job which completed</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task StartNextThrottledJobAsync(JobDocument previousJob, CancellationToken cancellationToken);

        /// <summary>
        /// Check whether the specified job should be throttled, and perform the appropriate throttling action if so.
        /// </summary>
        /// <param name="job">The job to check/throttle</param>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<(ThrottleReason Reason, string Message)> ThrottleAsync(JobDocument job, IRequestContext requestContext, CancellationToken cancellationToken);
    }
}
