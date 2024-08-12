using Azure.Messaging.ServiceBus;
using Company.Core.ServiceBus;
using SqlApi.AsyncService.Common.AsyncContracts;
using SqlApi.AsyncService.Common.DataAccess;
using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.Models;
using SqlApi.AsyncService.Common.ServiceClients.BroadcastServiceClient;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace SqlApi.AsyncService.Common.BusinessLogic
{
    /// <inheritdoc/>
    public class JobsChangeProcessor : IJobsChangeProcessor
    {
        private readonly ServiceBusSender _sender;
        private readonly IAzureStorageAdapter _storageAdapter;
        private readonly string _source;

        private readonly List<JobStatus> _terminalJobStatuses = new() { JobStatus.Completed, JobStatus.Cancelled, JobStatus.Failed };

        private const int EXPORT_NOTIFICATION_LIFETIME = 86400; // 24 hours
        private readonly IBroadcastServiceClient _broadcastServiceClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="storageAdapter"></param>
        /// <param name="topicFactory"></param>
        /// <param name="broadcastServiceClient"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public JobsChangeProcessor(IConfiguration configuration, IAzureStorageAdapter storageAdapter, ITopicFactory topicFactory, IBroadcastServiceClient broadcastServiceClient)
        {
            if (configuration is null) throw new ArgumentNullException(nameof(configuration));

            _source = $@"{configuration["EngSys:Zone"]}\nsa-async";
            _storageAdapter = storageAdapter ?? throw new ArgumentNullException(nameof(storageAdapter));
            _sender = topicFactory?.Topics["nsa-async-jobs"].Sender ?? throw new ArgumentNullException(nameof(Topic));
            _broadcastServiceClient = broadcastServiceClient ?? throw new ArgumentNullException(nameof(broadcastServiceClient));
        }

        /// <inheritdoc/>
        public async Task ProcessChangesAsync(IReadOnlyList<JobDocument> jobs, CancellationToken cancellationToken)
        {
            var terminalJobs = jobs.Where(d => _terminalJobStatuses.Contains(d.Status));

            if (terminalJobs.Any())
            {
                foreach (var job in terminalJobs)
                {
                    var tasks = new List<Task>();

                    var entity = new NsaAsyncJobContract()
                    {
                        EnvironmentId = job.PartitionKey,
                        Source = _source,
                        NsaAsyncJob = new NsaAsyncJob()
                        {
                            Id = job.Id,
                            Audience = job.Audience,
                            CommandId = job.CommandId,
                            Description = job.Description,
                            EnvironmentId = job.PartitionKey,
                            CreateDate = job.CreateDate,
                            RunDate = job.RunDate,
                            EndDate = job.EndDate,
                            Product = job.Product.ToString(),
                            UxMode = job.UXMode.ToString(),
                            Status = job.Status.ToString(),
                            UserId = job.UserId,
                            SasUris = job.Status == JobStatus.Completed ? (await _storageAdapter.GetBlobReadUrisAsync(job, BlobContentDisposition.Inline, cancellationToken)).ToList() : null,
                            ErrorMessage = job.ErrorMessage
                        }
                    };

                    tasks.Add(SendMessageAsync(entity, cancellationToken));

                    if (job.SendNotification)
                    {
                        if (job.Status == JobStatus.Completed)
                        {
                            tasks.Add(SendSuccessNotification(entity, cancellationToken));
                        }
                        else if (job.Status == JobStatus.Failed)
                        {
                            tasks.Add(SendFailureNotification(entity, cancellationToken));
                        }
                    }

                    if (job.NotificationInfo != null)
                    {
                        if (job.Status == JobStatus.Completed)
                        {
                            tasks.Add(SendSuccessNotification(job, cancellationToken));
                        }
                        else if (job.Status == JobStatus.Failed)
                        {
                            tasks.Add(SendFailureNotification(job, cancellationToken));
                        }
                    }

                    await Task.WhenAll(tasks);
                }
            }
        }

        /// <summary>
        /// Sends message to Service Bus.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendMessageAsync(NsaAsyncJobContract entity, CancellationToken cancellationToken)
        {
            var message = entity.BuildMessage();
            message.MessageId = Guid.NewGuid().ToString();

            message.ApplicationProperties.Add("audience", entity.NsaAsyncJob.Audience);

            await _sender.SendMessageAsync(message, cancellationToken);
        }

        /// <summary>
        /// Sends notification to user that job is complete and ready for pickup.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendSuccessNotification(NsaAsyncJobContract entity, CancellationToken cancellationToken)
        {
            var job = entity.NsaAsyncJob;
            var svcId = job.Product switch
            {
                "RE" => "renxt",
                "FE" => "fenxt",
                _ => throw new ArgumentOutOfRangeException()
            };

            var body = new CreateNotificationRequest()
            {
                NotificationType = "nsa_async_query_success",
                ExpiresIn = EXPORT_NOTIFICATION_LIFETIME,
                Recipients = new List<CreateNotificationRequestRecipientDto>
                {
                    new() {
                        RecipientId = job.UserId,
                        EnvironmentId = job.EnvironmentId
                    }
                },
                Severity = Severity.Success,
                ShortMessage = "Your query export is complete. Click to open the download page.",
                MoreInfoAppLink = new AppLinkDto
                {
                    App = "query",
                    Route = "/download/:jobId",
                    Params = new Dictionary<string, string>
                    {
                        [":jobId"] = job.Id,
                        ["envid"] = job.EnvironmentId,
                        ["svcid"] = svcId,
                    }
                }
            };

            await _broadcastServiceClient.CreateNotificationAsync(body, cancellationToken);
        }

        /// <summary>
        /// Sends notification to user that the job has failed.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendFailureNotification(NsaAsyncJobContract entity, CancellationToken cancellationToken)
        {
            var job = entity.NsaAsyncJob;

            var body = new CreateNotificationRequest()
            {
                NotificationType = "nsa_async_query_failed",
                ExpiresIn = EXPORT_NOTIFICATION_LIFETIME,
                Recipients = new List<CreateNotificationRequestRecipientDto>
                {
                    new() {
                        RecipientId = job.UserId,
                        EnvironmentId = job.EnvironmentId
                    }
                },
                Severity = Severity.Danger,
                ShortMessage = "The query export failed."
            };
            await _broadcastServiceClient.CreateNotificationAsync(body, cancellationToken);
        }

        /// <summary>
        /// Sends notification to user that job is complete and ready for pickup.
        /// </summary>
        /// <param name="job"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendSuccessNotification(JobDocument job, CancellationToken cancellationToken)
        {
            var svcId = job.Product.ToString() switch
            {
                "RE" => "renxt",
                "FE" => "fenxt",
                _ => throw new ArgumentOutOfRangeException()
            };

            var body = new CreateNotificationRequest()
            {
                NotificationType = "nsa_async_query_success",
                ExpiresIn = EXPORT_NOTIFICATION_LIFETIME,
                Recipients = new List<CreateNotificationRequestRecipientDto>
                {
                    new() {
                        RecipientId = job.UserId,
                        EnvironmentId = job.PartitionKey,
                    }
                },
                Severity = Severity.Success,
                ShortMessage = job.NotificationInfo.SuccessMessage,
                MoreInfoAppLink = new AppLinkDto
                {
                    App = "query",
                    Route = "/download/:jobId",
                    Params = new Dictionary<string, string>
                    {
                        [":jobId"] = job.Id,
                        ["envid"] = job.PartitionKey,
                        ["svcid"] = svcId,
                    }
                }
            };

            await _broadcastServiceClient.CreateNotificationAsync(body, cancellationToken);
        }

        /// <summary>
        /// Sends notification to user that the job has failed.
        /// </summary>
        /// <param name="job"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task SendFailureNotification(JobDocument job, CancellationToken cancellationToken)
        {
            var body = new CreateNotificationRequest()
            {
                NotificationType = "nsa_async_query_failed",
                ExpiresIn = EXPORT_NOTIFICATION_LIFETIME,
                Recipients = new List<CreateNotificationRequestRecipientDto>
                {
                    new() {
                        RecipientId = job.UserId,
                        EnvironmentId = job.PartitionKey,
                    }
                },
                Severity = Severity.Danger,
                ShortMessage = job.NotificationInfo.FailMessage,
            };
            await _broadcastServiceClient.CreateNotificationAsync(body, cancellationToken);
        }
    }
}
