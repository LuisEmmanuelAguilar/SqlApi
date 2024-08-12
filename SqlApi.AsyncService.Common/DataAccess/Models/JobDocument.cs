using SqlApi.AsyncService.Common.Models;
using Company.Records.Cosmos.Models;
using Newtonsoft.Json;
using Azure.Storage.Blobs.Models;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace SqlApi.AsyncService.Common.DataAccess.Models
{
    /// <summary>
    /// A job to run a query
    /// </summary>
    public class JobDocument : PartitionedDocument
    {
        /// <inheritdoc/>
        public override string Id { get; set; }

        /// <summary>
        /// The type of the document
        /// </summary>
        public string DocumentType { get; set; } = "Job";

        /// <summary>
        /// Partition key for the document
        /// </summary>
        public override string PartitionKey { get; set; }

        /// <summary>
        /// The calling service
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Optional override for the SAS identity (including zone) the SQL API backend should call to get the SQL.
        /// If not specified, the Audience will be used.
        /// </summary>
        public string CommandService { get; set; }

        /// <summary>
        /// Id of the command
        /// </summary>
        public string CommandId { get; set; }

        /// <summary>
        /// <see cref="SqlParameter"/>s for the job
        /// </summary>
        /// <remarks>The native SqlParameter class doesn't serialize its value, so we represent these as key/value pairs.</remarks>
        public IReadOnlyDictionary<string, SqlParameter> SqlParameters { get; set; }

        /// <summary>
        /// A description to help identify the job
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// When the job was created
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// When the job was marked running
        /// </summary>
        public DateTime? RunDate { get; set; }

        /// <summary>
        /// When the job was marked completed, cancelled, or failed
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// The last time the job was touched by the backend
        /// </summary>
        public DateTime? Heartbeat { get; set; }

        /// <summary>
        /// The last time the job was polled by the browser
        /// </summary>
        public DateTime? UXHeartbeat { get; set; }

        /// <summary>
        /// The Product RE or FE
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// The user experience mode
        /// </summary>
        public UXMode UXMode { get; set; }

        /// <summary>
        /// Status of the job
        /// </summary>
        public JobStatus Status { get; set; }

        /// <summary>
        /// The user Id of the caller
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The number of retries on this job
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Retries { get; set; }

        /// <summary>
        /// History of changes on the job
        /// </summary>
        public List<JobEvent> History { get; set; }

        /// <summary>
        /// The culture to use for formatting
        /// </summary>
        public string Culture { get; set; }

        /// <summary>
        /// The installed country to use for formatting
        /// </summary>
        public Country InstalledCountry { get; set; }

        /// <summary>
        /// Gets or sets the formatting options for the result set.
        /// </summary>
        public IReadOnlyCollection<DataSetOptions> DataSetOptions { get; set; }

        /// <summary>
        /// Metrics for the job
        /// </summary>
        public JobMetrics Metrics { get; set; }

        /// <summary>
        /// Error message for a failed job
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The flag to check if a notification should be sent to user when the results are ready for download.
        /// </summary>
        public bool SendNotification { get; set; } = false;

        /// <summary>
        /// Information regarding notification to be sent
        /// </summary>
        public NotificationInfo NotificationInfo { get; set; } = null;
    }

    /// <summary>
    /// Audit history of an update to a job
    /// </summary>
    public class JobEvent
    {
        /// <summary>
        /// The date of the change
        /// </summary>
        public DateTime DateChanged { get; set; }

        /// <summary>
        /// The status value before the change
        /// </summary>
        public JobStatus PreviousStatus { get; set; }

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
