using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.Models;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SqlApi.AsyncService.BusinessLogic
{
    /// <summary>
    /// A service for interacting with query jobs
    /// </summary>
    public interface IJobService
    {
        /// <summary>
        /// Creates and executes a job
        /// </summary>
        /// <param name="createJobRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CreateJobResponse> CreateJob(CreateJobRequest createJobRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the job.
        /// Updates the heartbeat if called by the backend.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestId"></param>
        /// <param name="includeReadUrl"></param>
        /// <param name="contentDisposition"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Job> GetJob(string id, string requestId, IncludeReadUrl includeReadUrl, BlobContentDisposition contentDisposition, CancellationToken cancellationToken = default);

        /// <summary>
        /// Map a <see cref="JobDocument"/> to the specified type of <see cref="Job"/>.
        /// </summary>
        /// <param name="jobDocument"></param>
        /// <param name="includeReadUrl"></param>
        /// <param name="contentDisposition"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> MapJob<T>(JobDocument jobDocument, IncludeReadUrl includeReadUrl, BlobContentDisposition contentDisposition, CancellationToken cancellationToken)
            where T : Job, new();

        /// <summary>
        /// Get append blob write uri for the given sequence.
        /// </summary>
        /// <param name="id">The job id</param>
        /// <param name="sequence">The blob sequence. e.g. results_1.csv, results_2.csv</param>
        /// <param name="requestId">The request id</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> GetBlobWriteUriAsync(string id, int sequence, string requestId, CancellationToken cancellationToken = default);
    }
}
