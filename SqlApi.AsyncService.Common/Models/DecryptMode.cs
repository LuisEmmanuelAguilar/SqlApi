namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Field decryption behavior
    /// </summary>
    public enum DecryptMode
    {
        /// <summary>
        /// The field does not need to be decrypted
        /// </summary>
        None,

        /// <summary>
        /// The field value should be decrypted and returned as plain text
        /// </summary>
        Decrypt,

        /// <summary>
        /// The field value should be decrypted and then masked (X's except last 4 characters)
        /// </summary>
        Mask
    }
}
