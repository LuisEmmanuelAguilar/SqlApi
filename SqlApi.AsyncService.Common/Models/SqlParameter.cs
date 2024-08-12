using System.Data;

namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// Class to represent necessary parameters for SQL command execution.
    /// </summary>
    public class SqlParameter
    {
        /// <summary>
        /// Gets or sets the parameter value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the parameter Sql data type.
        /// </summary>
        public SqlDbType? SqlDbType { get; set; }

        /// <summary>
        /// Gets or sets if Dynamic Sql Depends on this parameter.
        /// </summary>
        public bool? IsDynamicDependent { get; set; }
    }
}
