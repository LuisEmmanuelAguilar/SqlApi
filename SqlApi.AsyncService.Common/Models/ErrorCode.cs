namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Invalid input error types
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// {0}.format is Legacy but {0}.legacy_format_descriptor is None
        /// </summary>
        FieldFormatOptionsLegacyRequiresFormatDescriptor,

        /// <summary>
        /// {0}.format is not Legacy but {0}.legacy_format_descriptor is not None
        /// </summary>
        FieldFormatOptionsNonLegacyShouldNotSpecifyFormatDescriptor,

        /// <summary>
        /// {0}.formatting_options has multiple entries for the same field name
        /// </summary>
        DataSetOptionsFieldNamesMustBeUnique,

        /// <summary>
        /// Invalid relative date filter
        /// </summary>
        InvalidRelativeDateFilter,

        /// <summary>
        /// Request must include valid UserId if Notification is to be sent
        /// </summary>
        NotificationMustIncludeUserId,

        /// <summary>
        /// The data set file names provided would result in duplicate file names.
        /// </summary>
        DataSetOptionsFileNamesMustBeUnique
    }
}
