namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Describes the type of content that will be returned from storage
    /// </summary>
    public enum BlobContentDisposition
    {
        /// <summary>
        /// Inline is displayed in the browser
        /// </summary>
        Inline,

        /// <summary>
        /// Attachment is downloaded
        /// </summary>
        Attachment
    }
}
