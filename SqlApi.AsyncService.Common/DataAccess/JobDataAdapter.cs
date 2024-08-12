using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.Models;
using Company.Records.Cosmos;
using Microsoft.Azure.Cosmos;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace SqlApi.AsyncService.Common.DataAccess
{
    /// <summary>
    /// A cosmos data adapter for job records
    /// </summary>
    public class JobDataAdapter : IJobDataAdapter
    {
        private readonly Container _container;

        /// <summary>
        /// Constructs a ExampleDataAdapter
        /// </summary>
        public JobDataAdapter(IContainerProvider containerProvider)
        {
            _container = containerProvider.GetDefaultContainer("nsaasyncdb", "jobs");
        }

        /// <inheritdoc/>
        public async Task UpsertJob(JobDocument job, CancellationToken cancellationToken)
        {
            var requestOptions = new ItemRequestOptions { IfMatchEtag = job.ETag, EnableContentResponseOnWrite = false };
            var response = await _container.UpsertItemAsync(job, new PartitionKey(job.PartitionKey), requestOptions, cancellationToken);

            if (!string.IsNullOrWhiteSpace(response.ETag)) job.ETag = response.ETag;
        }

        /// <inheritdoc/>
        public async Task<JobDocument> GetJob(string id, string partitionKey, CancellationToken cancellationToken)
        {
            try
            {
                return await _container.ReadItemAsync<JobDocument>(id, new PartitionKey(partitionKey), cancellationToken: cancellationToken);
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<JobDocument>> QueryJobs(QueryDefinition query, QueryRequestOptions options = null, CancellationToken cancellationToken = default)
        {
            var jobs = new List<JobDocument>();

            using var feedIterator = _container.GetItemQueryIterator<JobDocument>(query, requestOptions: options);
            while (feedIterator.HasMoreResults)
            {
                foreach (JobDocument job in await feedIterator.ReadNextAsync(cancellationToken))
                {
                    jobs.Add(job);
                }
            }
            return jobs;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> QueryValues<T>(QueryDefinition query, QueryRequestOptions options = null, CancellationToken cancellationToken = default)
        {
            var values = new List<T>();
            using var feedIterator = _container.GetItemQueryIterator<T>(query, requestOptions: options);

            while (feedIterator.HasMoreResults)
            {
                var response = await feedIterator.ReadNextAsync(cancellationToken);
                values.AddRange(response);
            }

            return values;
        }

        /// <inheritdoc/>
        public async Task<Dictionary<string, int>> GetJobCountsAsync(Product product, string partitionKey, IEnumerable<JobStatus> jobStatuses, IEnumerable<string> userIds = null, CancellationToken cancellationToken = default)
        {
            var countByUserSelectClauses = userIds?.Select((userId, index) => $"count(iif(j.UserId = @userId{index}, 1, undefined)) as \"{userId}\"") ?? Enumerable.Empty<string>();
            var sql = $@"
        select 
            COUNT(j.id) As ""{partitionKey}""
            {(countByUserSelectClauses.Any() ? $",{string.Join($",{Environment.NewLine}", countByUserSelectClauses)}" : string.Empty)}
        from j
        where j.PartitionKey = @partitionKey
            and j.Product = {(int)product}
            and j.Status {(jobStatuses.Count() == 1 ? $"= {(int)jobStatuses.First()}" : $"in ({string.Join(", ", jobStatuses.Select(s => (int)s))})")}";

            var query = new QueryDefinition(sql);
            query.WithParameter("@partitionKey", partitionKey);

            if (userIds?.Any() ?? false)
            {
                var index = 0;
                foreach (var userId in userIds)
                {
                    query.WithParameter($"@userId{index}", userId);
                    index++;
                }
            }

            var jobCounts = new Dictionary<string, int>();
            var counts = await QueryValues<Dictionary<string, int>>(query,
                new QueryRequestOptions() { PartitionKey = new PartitionKey(partitionKey) },
                cancellationToken);

            return counts.FirstOrDefault();
        }
    }
}
