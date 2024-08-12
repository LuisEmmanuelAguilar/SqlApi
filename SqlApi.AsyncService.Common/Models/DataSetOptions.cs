using Microsoft.AspNetCore.Http;

namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// The options to apply to a data set
    /// </summary>
    public class DataSetOptions
    {
        /// <summary>
        /// Optional parameter indicating the desired output format
        /// </summary>
        public OutputFormat OutputFormat { get; set; } = OutputFormat.csv;

        /// <summary>
        /// Field formatting options
        /// </summary>
        public IReadOnlyCollection<FieldFormatOptions> FormattingOptions { get; set; }

        /// <summary>
        /// File download name
        /// </summary>
        public string FileName { get; set; }
    }
}
