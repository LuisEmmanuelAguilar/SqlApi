using Newtonsoft.Json;

namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// The formatting options for a field
    /// </summary>
    public class FieldFormatOptions
    {
        /// <summary>
        /// The name of the field to which these options apply
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The <see cref="FieldFormat"/> to use; default is <see cref="FieldFormat.None"/>
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public FieldFormat Format { get; set; }

        /// <summary>
        /// The format mask to apply to the value
        /// </summary>
        public string FormatMask { get; set; }

        /// <summary>
        /// Required for <see cref="FieldFormat.Legacy"/>, the <see cref="LegacyFormatDescriptor"/> to use
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public LegacyFormatDescriptor LegacyFormatDescriptor { get; set; }

        /// <summary>
        /// Decryption logic to apply to the field (additional formatting logic can still be specified using the other fields and will be applied after decryption); default is None
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DecryptMode DecryptMode { get; set; }
    }
}
