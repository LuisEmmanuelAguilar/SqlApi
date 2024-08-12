using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlApi.AsyncService.Common.AsyncContracts
{
    internal class NsaAsyncJobContracts
    {
    }
}
using Company.Core.ServiceBus.Contracts;
using Newtonsoft.Json;

namespace SqlApi.AsyncService.Common.AsyncContracts
{
    /// <summary>
    /// Async entity contract for jobs
    /// </summary>
    public class NsaAsyncJobContract : AsyncContract
    {
        /// <summary>
        /// ContractId
        /// </summary>
        public override string ContractId => "24d525e9-05b7-ee11-bea0-000d3ae229a0";

        /// <summary>
        /// DataSchema
        /// </summary>
        public override string DataSchema => "/nsa-async/NsaAsyncJob";

        /// <summary>
        /// Operation
        /// </summary>
        public override MessageOperation Operation => MessageOperation.Upsert;

        /// <summary>
        /// The Message Payload
        /// </summary>
        [JsonProperty("nsa-async-job")]
        public NsaAsyncJob NsaAsyncJob { get; set; }
    }
}
