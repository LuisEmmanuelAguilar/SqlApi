using System.ComponentModel.DataAnnotations;

namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Create job response
    /// </summary>
    public class CreateJobResponse
    {
        /// <summary>
        /// The job identifier
        /// </summary>
        [Required]
        public string Id;

        /// <summary>
        /// Resulting status of the query job
        /// </summary>
        public JobStatus Status;

        /// <summary>
        /// Message expressing additional information about the job
        /// </summary>
        public string Message;
    }
}
