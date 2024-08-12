using Core.AzureStorageProxy;
using Core.WebService.AspNetCore;
using SqlApi.AsyncService.Authorization;
using SqlApi.AsyncService.BusinessLogic;
using SqlApi.AsyncService.Common.BusinessLogic;
using SqlApi.AsyncService.Common.DataAccess;
using SqlApi.AsyncService.Common.DataAccess.StorageProxy;
using SqlApi.AsyncService.Common.DataAdapters;
using SqlApi.AsyncService.Common.ServiceClients;
using Records.Cosmos;
using Records.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Data;

namespace SqlApi.AsyncService
{
    /// <summary>
    /// Startup class for configuring the web service.
    /// </summary>
    public class Startup
    {
        private IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor to inject Configuration
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration) => Configuration = configuration;

        /// <summary>
        /// Configure dependency injection container
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SqlApi.AsyncService.Common.xml"));
            });

            services.ConfigureCosmos(Configuration, "nsaasyncdb", true);
            services.AddStartupTask<AzureStorageStartupTask>();
            services.AddStartupTask<BlobStorageCorsSetupStartupTask>();
            services
                .AddSingleton<IJobDataAdapter, JobDataAdapter>()
                .AddSingleton<IBackendDataAdapter, BackendDataAdapter>()
                .AddServiceClient<IFEBackendSqlApiServiceClient, FEBackendSqlApiServiceClient>(false)
                .AddServiceClient<IREBackendSqlApiServiceClient, REBackendSqlApiServiceClient>(false)
                .AddScoped<IJobService, JobService>()
                .AddScoped<SupportalJobService>()
                .AddSingleton<IJobStatusService, JobStatusService>()
                .AddSingleton<IJobStatusServiceBase, JobStatusServiceBase>()
                .AddSingleton<IJobThrottlingService, JobThrottlingService>()
                .AddSingleton<IUrlRouteMaskingService, UrlRouteMaskingService>()
                .ConfigureValidationHelper();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddAzureClients(builder =>
            {
                builder.AddBlobServiceClient(Configuration.GetValue<string>("StorageAccount:nsaasyncstorage:ConnectionString"));
            });
            services.AddSingleton<IAzureStorageAdapter, AzureStorageAdapter>();
            services.AddStorageProxyServices();

            // TODO: Do we want monitor tests for Cosmos and the storage account?

            services.AddAuthorizationPolicies();
        }

        /// <summary>
        /// Configure ASP.NET Core MVC application
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            app.ConfigureCompany<Startup>();
            app.UseStorageProxy(Configuration);

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                Secure = CookieSecurePolicy.Always
            });
        }
    }
}
