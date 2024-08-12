using Core.Functions;
using SqlApi.AsyncService.Common.BusinessLogic;
using SqlApi.AsyncService.Common.DataAccess;
using SqlApi.AsyncService.Common.DataAccess.StorageProxy;
using SqlApi.AsyncService.Common.DataAdapters;
using SqlApi.AsyncService.Common.ServiceClients;
using SqlApi.AsyncService.Common.ServiceClients.BroadcastServiceClient;
using SqlApi.AsyncService.Functions;
using .Records.Cosmos;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
[assembly: FunctionsStartup(typeof(Startup))]
namespace SqlApi.AsyncService.Functions;

public class Startup : FunctionsStartup
{
    public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddServiceBus()
            .ConfigureCosmos(configuration, "nsaasyncdb");

        var accountEndpoint = configuration["Cosmos:nsaasyncdb:AccountEndpoint"];

        if (!string.IsNullOrWhiteSpace(accountEndpoint))
        {
            configuration["Cosmos:nsaasyncdb:ConnectionString"] = $"AccountEndpoint={accountEndpoint};AccountKey={configuration["Cosmos:nsaasyncdb:AccountKey"]};";
        }
        else
        {
            configuration["Cosmos:nsaasyncdb:ConnectionString"] = $"AccountEndpoint=https://{configuration["Cosmos:nsaasyncdb:AccountName"]}.documents.azure.com:443/;AccountKey={configuration["Cosmos:nsaasyncdb:AccountKey"]};";
        }

        services
            .AddSingleton<IJobsChangeProcessor, JobsChangeProcessor>()
            .AddSingleton<IJobStatusService, JobStatusService>()
            .AddSingleton<IJobStatusServiceBase, JobStatusServiceBase>()
            .AddSingleton<IJobThrottlingService, JobThrottlingService>()
            .AddSingleton<IJobDataAdapter, JobDataAdapter>()
            .AddSingleton<IBackendDataAdapter, BackendDataAdapter>()
            .AddSingleton<IUrlRouteMaskingService, UrlRouteMaskingService>()
            .AddServiceClient<IFEBackendSqlApiServiceClient, FEBackendSqlApiServiceClient>(false)
            .AddServiceClient<IREBackendSqlApiServiceClient, REBackendSqlApiServiceClient>(false)
            .AddServiceClient<IBroadcastServiceClient, BroadcastServiceClient>(false);

        services.AddAzureClients(builder =>
        {
            builder.AddBlobServiceClient(configuration.GetValue<string>("StorageAccount:nsaasyncstorage:ConnectionString"));
        });
        services.AddSingleton<IAzureStorageAdapter, AzureStorageAdapter>();
    }
}