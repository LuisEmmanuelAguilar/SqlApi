using Company.NSwag.Client;
using Company.NXT.SqlApi.AsyncService.Common.ServiceClients.BackendSqlApiService;

namespace Company.NXT.SqlApi.AsyncService.Common.ServiceClients
{
    /// <summary>
    /// Raiser's Edge Backend Service Client
    /// </summary>
    public class REBackendSqlApiServiceClient : BackendSqlApiServiceClient, IREBackendSqlApiServiceClient
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public REBackendSqlApiServiceClient(ClientConfig<IREBackendSqlApiServiceClient> config) : base(config) { }
    }

    /// <summary>
    /// Interface for Raiser's Edge Backend Service Client
    /// </summary>
    public interface IREBackendSqlApiServiceClient : IBackendSqlApiServiceClient { }
}

