namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Represents the supported value formats for query fields.
    /// </summary>
    public enum FieldFormat
    {
        /// <summary>
        /// No additional formatting should be applied to the value.
        /// </summary>
        None,

        /// <summary>
        /// Apply legacy formatting to the value.  Requires LegacyFormatDescriptor.
        /// </summary>
        Legacy,

        /// <summary>
        /// Convert to a decimal then to a string using the FormatMask.  If no FormatMask is supplied, the default format for the Culture on the request is used.
        /// </summary>
        Decimal,

        /// <summary>
        /// Convert to a DateTime then to a string using the FormatMask.  If no FormatMask is supplied, the short date format for the Culture on the request is used.
        /// </summary>
        DateTime,

        /// <summary>
        /// Remove carriage returns from a possible multi-line value.
        /// </summary>
        Multiline
    }
}
