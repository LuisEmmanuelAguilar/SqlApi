namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// User experience mode
    /// </summary>
    public enum UXMode
    {
        /// <summary>
        /// Some form of UI is waiting for the job to complete
        /// </summary>
        Synchronous = 0,

        /// <summary>
        /// UI running query in the background
        /// </summary>
        Asynchronous = 1
    }
}
