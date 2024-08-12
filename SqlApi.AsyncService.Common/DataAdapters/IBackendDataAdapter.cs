using SqlApi.AsyncService.Common.DataAccess.Models;

namespace SqlApi.AsyncService.Common.DataAdapters
{
    /// <summary>
    /// Interface for interacting with Backend services
    /// </summary>
    public interface IBackendDataAdapter
    {
        /// <summary>
        /// Queue async execution of a query job
        /// </summary>
        /// <param name="job">The job to be queued.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task QueueQueryExecutionAsync(JobDocument job, CancellationToken cancellationToken);
    }
}
