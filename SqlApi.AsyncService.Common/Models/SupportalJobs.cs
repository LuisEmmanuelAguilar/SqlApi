using Newtonsoft.Json;

namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// The full version of the job for supportal
    /// </summary>
    public class SupportalJob : Job
    {
        /// <summary>
        /// The last time the job was touched by the backend
        /// </summary>
        [JsonProperty(Order = 1)]
        public DateTime? Heartbeat { get; set; }

        /// <summary>
        /// The last time the job was polled by the browser
        /// </summary>
        [JsonProperty(Order = 1)]
        public DateTime? UXHeartbeat { get; set; }

        /// <summary>
        /// The number of retries on this job
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, Order = 1)]
        public int Retries { get; set; }

        /// <summary>
        /// History of changes on the job
        /// </summary>
        [JsonProperty(Order = 1)]
        public List<SupportalJobEvent> History { get; set; }

        /// <summary>
        /// Metrics for the job
        /// </summary>
        [JsonProperty(Order = 1)]
        public JobMetrics Metrics { get; set; }
    }

    /// <summary>
    /// History event for a supportal job
    /// </summary>
    public class SupportalJobEvent
    {
        /// <summary>
        /// The status value before the change
        /// </summary>
        public JobStatus? PreviousStatus { get; set; }

        /// <summary>
        /// The status value after the change
        /// </summary>
        public JobStatus NewStatus { get; set; }

        /// <summary>
        /// The date of the change
        /// </summary>
        public DateTime DateChanged { get; set; }

        /// <summary>
        /// How much time passed between this event and the previous event (how long the job was in the previous state)
        /// </summary>
        public TimeSpan? DurationAtPreviousStatus { get; set; }

        /// <summary>
        /// The user that made the change
        /// </summary>
        public string ChangedBy { get; set; }

        /// <summary>
        /// The service that made the request that made the change
        /// </summary>
        public string Service { get; set; }
    }
}
