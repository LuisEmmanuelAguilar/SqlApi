using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SqlApi.AsyncService.Common.Models
{
    internal class CreateJobRequest
    {
    }
}
using System.ComponentModel.DataAnnotations;

namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Properties about the create job request
    /// </summary>
    public class CreateJobRequest
    {
        /// <summary>
        /// The command id to execute
        /// </summary>
        [Required]
        public string CommandId { get; set; }

        /// <summary>
        /// The Id of the user making the request
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The product to make a request to
        /// </summary>
        [Required]
        public Product Product { get; set; }

        /// <summary>
        /// The description of the request
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Optional parameter indicating the user experience
        /// </summary>
        public UXMode UXMode { get; set; } = UXMode.Synchronous;

        /// <summary>
        /// Optional parameter to pass in the job id to be used
        /// </summary>
        public string JobId { get; set; }

        /// <summary>
        /// <see cref="SqlParameter"/>s for the job
        /// </summary>
        /// <remarks>The native SqlParameter class doesn't serialize its value, so we represent these as key/value pairs.</remarks>
        public IReadOnlyDictionary<string, SqlParameter> SqlParameters { get; set; }

        /// <summary>
        /// Gets or sets the formatting options for the result set.
        /// </summary>
        public IReadOnlyCollection<DataSetOptions> DataSetOptions { get; set; }

        /// <summary>
        /// The culture to use for formatting (default en-US)
        /// </summary>
        public string Culture { get; set; } = "en-US";

        /// <summary>
        /// The installed country to use for formatting (default US)
        /// </summary>
        public Country InstalledCountry { get; set; } = Country.US;

        /// <summary>
        /// Optional override for the SAS identity (including zone) the SQL API backend should call to get the SQL.
        /// If not specified, the TrustedCallerClientName will be used.
        /// </summary>
        public string CommandService { get; set; }

        /// <summary>
        /// The flag to check if a notification should be sent to user when the is job complete.
        /// </summary>
        public bool SendNotification { get; set; } = false;

        /// <summary>
        /// Information regarding notification to be sent
        /// </summary>
        public NotificationInfo NotificationInfo { get; set; } = null;
    }
}
