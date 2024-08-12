using System.Threading;
using System.Threading.Tasks;
using ServiceStatus.Contracts;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Hosting;

namespace SqlApi.AsyncService
{
    /// <summary>
    /// CORS Setup Startup Task
    /// </summary>
    public class BlobStorageCorsSetupStartupTask : StartupTask
    {

        private readonly string _storageAccountConnStr;

        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="config"></param>
        public BlobStorageCorsSetupStartupTask(IConfiguration config) : base("Cors Setup startup")
        {
            _storageAccountConnStr = config.GetValue<string>("StorageAccount:nsaasyncstorage:ConnectionString");
        }

        /// <summary>
        /// Execute the startup task to configure CORS
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task Execute(CancellationToken cancellationToken)
        {
            var service = new BlobServiceClient(_storageAccountConnStr);
            var propertyRequest = await service.GetPropertiesAsync(cancellationToken);
            var serviceProperties = propertyRequest?.Value;

            if (serviceProperties != null)
            {
                serviceProperties.Cors.Clear();

                // Add GET for host.nxt.Company.com
                serviceProperties.Cors.Add(new BlobCorsRule
                {
                    AllowedOrigins = "https://host.nxt.Company.com",
                    AllowedMethods = "GET,HEAD",
                    ExposedHeaders = "x-ms-meta-rowcount",
                    MaxAgeInSeconds = 1800, // 30 min
                });

                await service.SetPropertiesAsync(serviceProperties, cancellationToken);
            }

        }
    }
}
