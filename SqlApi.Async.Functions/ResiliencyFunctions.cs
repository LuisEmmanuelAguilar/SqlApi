using Core.Observability;
using SqlApi.AsyncService.Common.BusinessLogic;
using SqlApi.AsyncService.Common.DataAccess;
using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.DataAdapters;
using SqlApi.AsyncService.Common.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Text.Json;
using System.Xml.Linq;

namespace SqlApi.AsyncService.Functions;

public class ResiliencyFunctions
{
    const string EXOP = "operation";
    const string EXID = "job";

    private readonly int _resiliencyTimeoutSeconds;
    private readonly int _uxTimeoutSeconds;
    private readonly IJobStatusService _jobStatusService;
    private readonly IJobDataAdapter _jobDataAdapter;
    private readonly IBackendDataAdapter _backendAdapter;
    private readonly ILogger _logger;
    private readonly ITraceOperationFactory _traceOperationFactory;

    public ResiliencyFunctions(
        IConfiguration configuration,
        IJobStatusService jobStatusService,
        IJobDataAdapter jobDataAdapter,
        IBackendDataAdapter backendDataAdapter,
        ILogger<ResiliencyFunctions> logger,
        ITraceOperationFactory traceOperationFactory)
    {
        _resiliencyTimeoutSeconds = -1 * configuration.GetValue("ResiliencyTimeoutSeconds", 30);
        _uxTimeoutSeconds = -1 * configuration.GetValue("UXTimeoutSeconds", 20);
        _jobStatusService = jobStatusService;
        _jobDataAdapter = jobDataAdapter;
        _backendAdapter = backendDataAdapter ?? throw new ArgumentNullException(nameof(backendDataAdapter));
        _logger = logger;
        _traceOperationFactory = traceOperationFactory;
    }

    [FunctionName("ResiliencyFunction")]
#pragma warning disable IDE0060 // Remove unused parameter
    public async Task ResiliencyFunction([TimerTrigger("%ResiliencyPollingSchedule%")] TimerInfo timer, CancellationToken cancellationToken)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        // Get a list of stuck jobs to manage.
        var jobs = await GetStuckJobs(cancellationToken);

        if (jobs.Any())
        {
            using var op = _traceOperationFactory.StartOperation("ResiliencyFunction", jobs);
            op.Tag("ResiliencyTaskCount", jobs.Count());
            op.Tag("CancellingCount", jobs.Count(j => j.Status == JobStatus.Cancelling));
            op.Tag("PendingCount", jobs.Count(j => j.Status == JobStatus.Pending));
            op.Tag("RunningCount", jobs.Count(j => j.Status == JobStatus.Running));

            var parallelTasks = new List<Task>();

            foreach (var job in jobs)
            {
                using var scope = _logger.BeginScope(new Dictionary<string, object>
                {
                    ["JobId"] = job.Id,
                    ["EnvironmentId"] = job.PartitionKey,
                    ["Product"] = job.Product,
                    ["UserId"] = job.UserId
                });

                if (job.UXMode == UXMode.Synchronous && job.UXHeartbeat < DateTime.UtcNow.AddSeconds(_uxTimeoutSeconds))
                {
                    if (job.Heartbeat < DateTime.UtcNow.AddSeconds(_resiliencyTimeoutSeconds))
                    {
                        parallelTasks.Add(MarkJobCancelled(job, cancellationToken));
                    }
                    else
                    {
                        parallelTasks.Add(MarkJobCancelling(job, cancellationToken));
                    }

                }
                else
                {
                    switch (job.Status)
                    {
                        case JobStatus.Cancelling:
                            parallelTasks.Add(MarkJobCancelled(job, cancellationToken));
                            break;
                        case JobStatus.Running:
                        case JobStatus.Pending:
                            parallelTasks.Add(HandleStuckRunningJob(job, cancellationToken));
                            break;
                        default:
                            _logger.LogError("Unexpected job status {JobStatus} in resiliency function", job.Status);
                            break;
                    }
                }
            }

            int preconditionFailedCount = 0;
            int tooManyRequestsCount = 0;
            int unhandledExceptionCount = 0;

            var whenall = Task.WhenAll(parallelTasks);
            try
            {
                await whenall;
            }
            catch
            {
                whenall.Exception.Handle(innerEx =>
                {
                    if (innerEx is CosmosException cosmosEx &&
                        (cosmosEx.StatusCode == HttpStatusCode.PreconditionFailed ||
                         cosmosEx.StatusCode == HttpStatusCode.TooManyRequests))
                    {
                        switch (cosmosEx.StatusCode)
                        {
                            case HttpStatusCode.PreconditionFailed:
                                preconditionFailedCount++;
                                break;
                            case HttpStatusCode.TooManyRequests:
                                tooManyRequestsCount++;
                                break;
                        }
                    }
                    else
                    {
                        unhandledExceptionCount++;
                        _logger.LogError(innerEx, TranslateResiliencyExceptionMessage(innerEx));
                    }
                    return true;
                });
            }

            op.Tag("PreconditionFailedCount", preconditionFailedCount);
            op.Tag("TooManyRequestsCount", tooManyRequestsCount);
            op.Tag("UnhandledExceptionCount", unhandledExceptionCount);
            op.Complete();
        }
    }

    public async Task<IEnumerable<JobDocument>> GetStuckJobs(CancellationToken cancellationToken)
    {
        var query = new QueryDefinition($"select * from c where (c.Status in ({(int)JobStatus.Pending}, {(int)JobStatus.Running}, {(int)JobStatus.Cancelling}) and c.Heartbeat < \"{DateTime.UtcNow.AddSeconds(_resiliencyTimeoutSeconds):o}\")" +
            $" or (c.UXMode = {(int)UXMode.Synchronous} and c.Status in ({(int)JobStatus.Running}, {(int)JobStatus.Pending})  and c.UXHeartbeat < \"{DateTime.UtcNow.AddSeconds(_uxTimeoutSeconds):o}\")");

        return await _jobDataAdapter.QueryJobs(query, cancellationToken: cancellationToken);
    }

    public async Task HandleStuckRunningJob(JobDocument job, CancellationToken cancellationToken)
    {
        await MarkJobPending(job, cancellationToken);
        await RestartJob(job, cancellationToken);

        _logger.LogInformation("Resiliency function restarted job.");
    }

    public async Task RestartJob(JobDocument job, CancellationToken cancellationToken)
    {
        try
        {
            await _backendAdapter.QueueQueryExecutionAsync(job, cancellationToken);
        }
        catch (Exception queueExecutionException)
        {
            try
            {
                await _jobStatusService.MarkJobFailed(job, cancellationToken);
            }
            catch (Exception markFailedException)
            {
                var agg = new AggregateException(queueExecutionException, markFailedException);
                agg.Data.Add(EXOP, "RestartJob_MarkJobFailed");
                agg.Data.Add(EXID, job.Id);
                throw agg;
            }

            queueExecutionException.Data.Add(EXOP, "RestartJob");
            queueExecutionException.Data.Add(EXID, job.Id);
            throw;
        }
    }

    public async Task MarkJobCancelled(JobDocument job, CancellationToken cancellationToken)
    {
        try
        {
            await _jobStatusService.MarkJobCancelled(job, cancellationToken);
        }
        catch (Exception e)
        {
            e.Data.Add(EXOP, "MarkJobCancelled");
            e.Data.Add(EXID, job.Id);
            throw;
        }

        _logger.LogInformation("Resiliency function cancelled job.");
    }

    public async Task MarkJobCancelling(JobDocument job, CancellationToken cancellationToken)
    {
        try
        {
            await _jobStatusService.MarkJobCancelling(job, cancellationToken);
        }
        catch (Exception e)
        {
            e.Data.Add(EXOP, "MarkJobCancelling");
            e.Data.Add(EXID, job.Id);
            throw;
        }

        _logger.LogInformation("Resiliency function set job status to cancelling.");
    }

    public async Task MarkJobPending(JobDocument job, CancellationToken cancellationToken)
    {
        try
        {
            job.Retries++;
            if (job.Retries > 2)
            {
                _logger.LogWarning("Job has an unexpected number of retries in resiliency function ({RetryCount})", job.Retries);
            }
            await _jobStatusService.MarkJobPending(job, cancellationToken);
        }
        catch (Exception e)
        {
            e.Data.Add(EXOP, "MarkJobPending");
            e.Data.Add(EXID, job.Id);
            throw;
        }
    }

    private static string TranslateResiliencyExceptionMessage(Exception e)
    {
        return $"Resiliency function {(e.Data.Contains(EXOP) ? $"{e.Data[EXOP]} " : string.Empty)}failed{(e.Data.Contains(EXID) ? $" for job id {e.Data[EXID]}" : string.Empty)}.";
    }
}
