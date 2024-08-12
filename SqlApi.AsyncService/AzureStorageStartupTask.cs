using SqlApi.AsyncService.Common.DataAccess;
using ServiceStatus.Contracts;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Hosting;

namespace SqlApi.AsyncService
{
    /// <summary>
    /// Initializes Azure storage on startup
    /// </summary>
    public class AzureStorageStartupTask : StartupTask
    {
        private readonly IAzureStorageAdapter _azureStorageAdapter;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="azureStorageAdapter"></param>
        public AzureStorageStartupTask(IAzureStorageAdapter azureStorageAdapter) : base("Azure Storage startup")
        {
            _azureStorageAdapter = azureStorageAdapter;
        }


        /// <summary>
        /// Method called as part of the start up process
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task Execute(CancellationToken cancellationToken)
        {
            await _azureStorageAdapter.InitializeAsync(cancellationToken);
        }
    }
}
