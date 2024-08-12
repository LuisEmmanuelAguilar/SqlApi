namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Represents the status of the job
    /// </summary>
    public enum JobStatus
    {
        /// <summary>
        /// A job has been queued but has not yet started running.
        /// </summary>
        Pending,

        /// <summary>
        /// The job is running.
        /// </summary>
        Running,

        /// <summary>
        /// The job successfully completed.
        /// </summary>
        Completed,

        /// <summary>
        /// The job failed.
        /// </summary>
        Failed,

        /// <summary>
        /// Job cancellation has been requested.  The job may still complete successfully from this state.
        /// </summary>
        Cancelling,

        /// <summary>
        /// The job was cancelled.
        /// </summary>
        Cancelled,

        /// <summary>
        /// The job has been throttled
        /// </summary>
        Throttled
    }
}
