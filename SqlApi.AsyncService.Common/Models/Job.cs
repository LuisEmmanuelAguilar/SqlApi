using System.Xml.Linq;

namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Represents a query job
    /// </summary>
    public class Job
    {
        #region CosmosProperties

        /// <summary>
        /// The job id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The calling service
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// The SAS identity the SQL API backend will call to get the SQL.
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
        /// The environment Id, used for partitioning.
        /// </summary>
        public string EnvironmentId { get; set; }

        /// <summary>
        /// When the job was created
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// When the job was (last) marked running
        /// </summary>
        public DateTime? RunDate { get; set; }

        /// <summary>
        /// When the job was marked completed, cancelled, or failed
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Once the job has finished, the time from the <see cref="CreateDate"/> to the <see cref="EndDate"/>
        /// </summary>
        public TimeSpan? TotalDuration => EndDate.HasValue ? EndDate.Value - CreateDate : null;

        /// <summary>
        /// Once the job has finished, the time from the <see cref="RunDate"/> to the <see cref="EndDate"/>
        /// </summary>
        public TimeSpan? RunDuration => EndDate.HasValue ? EndDate.Value - RunDate : null;

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
        /// Error message for a failed job
        /// </summary>
        public string ErrorMessage { get; set; }

        #endregion

        /// <summary>
        /// The collection of sas uri of the job's results in Azure storage
        /// </summary>
        public IEnumerable<string> SasUris { get; set; }
    }
}
