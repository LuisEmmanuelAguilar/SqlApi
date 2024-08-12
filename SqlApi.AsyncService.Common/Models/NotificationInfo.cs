using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlApi.AsyncService.Common.Models
{
    internal class NotificationInfo
    {
    }
}
namespace SqlApi.AsyncService.Common.Models
{
    /// <summary>
    /// The options to apply to a notification
    /// </summary>
    public class NotificationInfo
    {
        /// <summary>
        /// Notification success message
        /// </summary>
        public string SuccessMessage { get; set; }

        /// <summary>
        /// Notification failure message
        /// </summary>
        public string FailMessage { get; set; }
    }
}
