using Company.NSwag.Client;
using SqlParameter = SqlApi.AsyncService.Common.ServiceClients.BackendSqlApiService.SqlParameter;
using BackendDataSetOptions = SqlApi.AsyncService.Common.ServiceClients.BackendSqlApiService.DataSetOptions;
using SqlApi.AsyncService.Common.Models;
using SqlApi.AsyncService.Common.ServiceClients;
using SqlApi.AsyncService.Common.ServiceClients.BackendSqlApiService;
using System.Data;

namespace SqlApi.AsyncService.Common.DataAdapters
{
    /// <summary>
    /// Backend data adapter for interacting with multiple backend services
    /// </summary>
    public class BackendDataAdapter : IBackendDataAdapter
    {
        private readonly IFEBackendSqlApiServiceClient _feBackendService;
        private readonly IREBackendSqlApiServiceClient _reBackendService;

        /// <summary>
        /// Constructor
        /// </summary>
        public BackendDataAdapter(IFEBackendSqlApiServiceClient feBackendServiceClient, IREBackendSqlApiServiceClient reBackendServiceClient)
        {
            _feBackendService = feBackendServiceClient ?? throw new ArgumentNullException(nameof(feBackendServiceClient));
            _reBackendService = reBackendServiceClient ?? throw new ArgumentNullException(nameof(reBackendServiceClient));
        }

        private IBackendSqlApiServiceClient GetBackendSqlApiServiceClient(Product product)
        {
            return product switch
            {
                Product.RE => _reBackendService,
                Product.FE => _feBackendService,
                _ => throw new NotImplementedException(),
            };
        }

        /// <inheritdoc/>
        public async Task QueueQueryExecutionAsync(DataAccess.Models.JobDocument job, CancellationToken cancellationToken)
        {
            var sqlParameters = job.SqlParameters?.ToDictionary(p => p.Key,
                p => new SqlParameter
                {
                    IsDynamicDependent = p.Value?.IsDynamicDependent,
                    SqlDbType = p.Value?.SqlDbType.HasValue ?? false ? Enum.Parse<SqlDbType>(p.Value.SqlDbType.ToString()) : null,
                    Value = p.Value?.Value
                })
                ?? new Dictionary<string, SqlParameter>();

            if (!sqlParameters.ContainsKey("Company-Query-Product"))
            {
                sqlParameters.Add("Company-Query-Product", new SqlParameter
                {
                    IsDynamicDependent = true,
                    SqlDbType = SqlDbType.NVarChar,
                    Value = job.Product.ToString()
                });
            }

            // Map to backend models
            var dataSetOptions = job.DataSetOptions?.Select(dataSetOption => new BackendDataSetOptions
            {
                OutputFormat = Enum.Parse<ServiceClients.BackendSqlApiService.OutputFormat>(dataSetOption.OutputFormat.ToString(), true),
                FormattingOptions = dataSetOption.FormattingOptions?.Select(fieldFormatOption => new ServiceClients.BackendSqlApiService.FieldFormatOptions
                {
                    Name = fieldFormatOption.Name,
                    Format = Enum.Parse<ServiceClients.BackendSqlApiService.FieldFormat>(fieldFormatOption.Format.ToString(), true),
                    FormatMask = fieldFormatOption.FormatMask,
                    LegacyFormatDescriptor = Enum.Parse<ServiceClients.BackendSqlApiService.LegacyFormatDescriptor>(fieldFormatOption.LegacyFormatDescriptor.ToString(), true),
                    DecryptMode = Enum.Parse<ServiceClients.BackendSqlApiService.DecryptMode>(fieldFormatOption.DecryptMode.ToString(), true)
                })
            });

            await GetBackendSqlApiServiceClient(job.Product)
                .QueueCommandAsync(Guid.Parse(job.CommandId),
                    new AsyncCommandByIdExecuteRequest
                    {
                        JobId = Guid.Parse(job.Id),
                        RequestId = job.Retries.ToString(),
                        ConsumerCallback = job.CommandService ?? job.Audience,
                        SqlParameters = sqlParameters,
                        Culture = job.Culture,
                        InstalledCountry = Enum.Parse<ServiceClients.BackendSqlApiService.Country>(job.InstalledCountry.ToString()),
                        DataSetOptions = dataSetOptions
                    },
                    new ServiceClientRequestOptions()
                    {
                        EnvironmentId = job.PartitionKey
                    },
                    cancellationToken);
        }
    }
}
