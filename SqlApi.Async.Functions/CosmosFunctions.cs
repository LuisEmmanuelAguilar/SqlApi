using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.BusinessLogic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using System.Text.Json;

namespace SqlApi.AsyncService.Functions
{
    public class CosmosFunctions
    {
        private readonly IJobsChangeProcessor _changeProcessor;
        private readonly ILogger _logger;

        public CosmosFunctions(IJobsChangeProcessor changeProcessor, ILogger<CosmosFunctions> logger)
        {
            _changeProcessor = changeProcessor;
            _logger = logger;
        }

        /// <summary>
        /// Publish terminated jobs 
        /// </summary>
        /// <param name="jobs"></param>
        /// <returns></returns>
        [FunctionName("PublishTerminatedJobs")]
        [ExponentialBackoffRetry(-1, "00:00:03", "00:00:30")]
        public async Task PublishTerminatedJobsAsync([CosmosDBTrigger(databaseName: "nsaasyncdb", containerName: "jobs",
            Connection = "Cosmos:nsaasyncdb:ConnectionString",
            LeaseContainerName = "jobs-cf-lease",
            CreateLeaseContainerIfNotExists = true,
            MaxItemsPerInvocation = 1000)]
            IReadOnlyList<JobDocument> jobs,
            CancellationToken cancellationToken)
        {
            try
            {
                await _changeProcessor.ProcessChangesAsync(jobs, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An exception occurred processing changed job documents.");

                // Trigger retry
                throw;
            }
        }
    }
}
