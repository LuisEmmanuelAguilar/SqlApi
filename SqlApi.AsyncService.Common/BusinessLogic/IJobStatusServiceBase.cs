using Azure.Storage.Blobs.Models;
using Company.Core.WebService.Contracts;
using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.Models;
using System.Text.Json;

namespace SqlApi.AsyncService.Common.BusinessLogic
{
    /// <summary>
    /// Service providing functionality related to job status management
    /// </summary>
    public interface IJobStatusServiceBase
    {
        /// <summary>
        /// Update a job to <see cref="JobStatus.Pending"/>.
        /// </summary>
        /// <param name="jobDocument"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task MarkJobPending(JobDocument jobDocument, CancellationToken cancellationToken);

        /// <summary>
        /// Update a job to <see cref="JobStatus.Running"/>.
        /// </summary>
        /// <param name="id">The job id</param>
        /// <param name="requestId">The request id</param>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task MarkJobRunning(string id, string requestId, IRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Update a job to <see cref="JobStatus.Cancelling"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestContext"></param>
        /// <param name="isSupportal"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task MarkJobCancelling(string id, IRequestContext requestContext, bool isSupportal, CancellationToken cancellationToken);

        /// <summary>
        /// Update a job to <see cref="JobStatus.Cancelling"/>.
        /// </summary>
        /// <param name="jobDocument"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task MarkJobCancelling(JobDocument jobDocument, CancellationToken cancellationToken);

        /// <summary>
        /// Update a job to <see cref="JobStatus.Completed"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestId"></param>
        /// <param name="jobMetrics"></param>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task MarkJobCompleted(string id, string requestId, JobMetrics jobMetrics, IRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Update a job to <see cref="JobStatus.Failed"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestId"></param>
        /// <param name="request"></param>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task MarkJobFailed(string id, string requestId, MarkFailedRequest request, IRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Update a job to <see cref="JobStatus.Failed"/>.
        /// </summary>
        /// <param name="jobDocument"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task MarkJobFailed(JobDocument jobDocument, CancellationToken cancellationToken);

        /// <summary>
        /// Update a job to <see cref="JobStatus.Cancelled"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestId"></param>
        /// <param name="jobMetrics"></param>
        /// <param name="requestContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task MarkJobCancelled(string id, string requestId, JobMetrics jobMetrics, IRequestContext requestContext, CancellationToken cancellationToken);

        /// <summary>
        /// Update a job to <see cref="JobStatus.Cancelled"/>.
        /// </summary>
        /// <param name="jobDocument"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task MarkJobCancelled(JobDocument jobDocument, CancellationToken cancellationToken);
    }
}
