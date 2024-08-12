using Newtonsoft.Json;

namespace SqlApi.AsyncService.Common.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class JobMetrics
    {
        public IReadOnlyDictionary<string, long> Operations { get; set; }

        public IEnumerable<DataSetMetrics> DataSets { get; set; }
    }

    public class DataSetMetrics
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Rows { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Columns { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long BlobBytes { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
