using Microsoft.AspNetCore.Mvc;

namespace SqlApi.AsyncService.Common.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class GetJobsRequest
    {
        [FromQuery(Name = "audience")]
        public string Audience { get; set; }

        [FromQuery(Name = "product")]
        public Product? Product { get; set; }

        [FromQuery(Name = "statuses")]
        public IEnumerable<JobStatus> Statuses { get; set; }

        [FromQuery(Name = "user_id")]
        public string UserId { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// Return jobs with a CreateDate greater than now minus the specified relative amount of time
        /// Syntax - [n][u]
        /// [n] = a number
        /// [u] = a unit, supported values: "m"=minutes, "h"=hours, "d"=days
        /// </summary>
        [FromQuery(Name = "relative_from_create_date")]
        public string RelativeFromCreateDate { get; set; }

        /// <summary>
        /// Return jobs with CreateDate having the date part of the specified date
        /// </summary>
        [FromQuery(Name = "create_date")]
        public DateTime? CreateDate { get; set; }
    }
}
