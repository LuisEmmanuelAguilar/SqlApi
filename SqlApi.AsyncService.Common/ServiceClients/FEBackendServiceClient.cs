using Company.NSwag.Client;
using Company.NXT.SqlApi.AsyncService.Common.ServiceClients.BackendSqlApiService;

namespace Company.NXT.SqlApi.AsyncService.Common.ServiceClients
{
    /// <summary>
    /// Fundraisers Edge Backend Service Client
    /// </summary>
    public class FEBackendSqlApiServiceClient : BackendSqlApiServiceClient, IFEBackendSqlApiServiceClient
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FEBackendSqlApiServiceClient(ClientConfig<IFEBackendSqlApiServiceClient> config) : base(config) { }
    }

    /// <summary>
    /// Interface for Fundraisers Edge Backend Service Client
    /// </summary>
    public interface IFEBackendSqlApiServiceClient : IBackendSqlApiServiceClient { }
}
