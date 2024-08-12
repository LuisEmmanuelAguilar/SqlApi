namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Output formats
    /// </summary>
    public enum OutputFormat
    {
        /// <summary>
        /// Comma-separated values
        /// </summary>
        csv = 0,

        /// <summary>
        /// JSON array
        /// </summary>
        json = 1,

        /// <summary>
        /// JSON Lines
        /// </summary>
        jsonl = 2,
    }
}
