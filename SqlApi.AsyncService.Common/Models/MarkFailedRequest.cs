namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Expanded back-end request when marking a job failed
    /// </summary>
    public class MarkFailedRequest : JobMetrics
    {
        /// <summary>
        /// The error message for the failed job
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
