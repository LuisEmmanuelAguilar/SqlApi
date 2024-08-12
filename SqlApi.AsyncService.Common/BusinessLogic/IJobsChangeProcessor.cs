using SqlApi.AsyncService.Common.DataAccess.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SqlApi.AsyncService.Common.BusinessLogic
{
    /// <summary>
    /// Service providing behavior related to job change processing
    /// </summary>
    public interface IJobsChangeProcessor
    {
        /// <summary>
        /// Process changed job documents, posting terminated jobs to the nsa-async-job SB topic.
        /// </summary>
        /// <param name="jobs"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task ProcessChangesAsync(IReadOnlyList<JobDocument> jobs, CancellationToken cancellationToken);
    }
}

