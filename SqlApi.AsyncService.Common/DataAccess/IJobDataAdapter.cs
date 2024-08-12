using SqlApi.AsyncService.Common.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlApi.AsyncService.Common.DataAccess
{
    internal class IJobDataAdapter
    {
    }
}
using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.Models;
using Microsoft.Azure.Cosmos;

namespace SqlApi.AsyncService.Common.DataAccess
{
    /// <summary>
    /// A cosmos data adapter for job records
    /// </summary>
    public interface IJobDataAdapter
    {
        /// <summary>
        /// Upserts a job document into the database.
        /// </summary>
        /// <param name="job"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpsertJob(JobDocument job, CancellationToken cancellationToken);

        /// <summary>
        /// Gets a job document from the database.
        /// </summary>
        /// <param name="id">Job identifier</param>
        /// <param name="paritionKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<JobDocument> GetJob(string id, string paritionKey, CancellationToken cancellationToken);

        /// <summary>
        /// Queries job documents from the database.
        /// </summary>
        /// <param name="query">Query definition</param>
        /// <param name="options">Query options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<IEnumerable<JobDocument>> QueryJobs(QueryDefinition query, QueryRequestOptions options = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Queries for a collection of values
        /// </summary>
        /// <typeparam name="T">Type of the values to be returned</typeparam>
        /// <param name="query">Query definition</param>
        /// <param name="options">Query options</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        Task<IEnumerable<T>> QueryValues<T>(QueryDefinition query, QueryRequestOptions options = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Count jobs in the given list of job statuses by the given partition key and each user identifier
        /// </summary>
        /// <param name="product"></param>
        /// <param name="partitionKey"></param>
        /// <param name="jobStatuses"></param>
        /// <param name="userIds"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Dictionary with counts keys by parition key and user id</returns>
        Task<Dictionary<string, int>> GetJobCountsAsync(Product product, string partitionKey, IEnumerable<JobStatus> jobStatuses, IEnumerable<string> userIds = null, CancellationToken cancellationToken = default);
    }
}
