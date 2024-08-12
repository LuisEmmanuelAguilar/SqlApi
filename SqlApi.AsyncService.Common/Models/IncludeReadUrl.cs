namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Describes when the sas url should be included on a job
    /// </summary>
    public enum IncludeReadUrl
    {
        /// <summary>
        /// Never
        /// </summary>
        Never,

        /// <summary>
        /// When the job has status Running or Completed
        /// </summary>
        OnceRunning,

        /// <summary>
        /// When the job has status Completed
        /// </summary>
        OnceCompleted
    }
}
