using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.DataAccess.StorageProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlApi.AsyncService.Common.DataAccess
{
    internal class AzureStorageAdapter
    {
    }
}
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Azure.Storage.Blobs.Models;
using SqlApi.AsyncService.Common.Models;
using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.DataAccess.StorageProxy;

namespace SqlApi.AsyncService.Common.DataAccess
{
    /// <summary>
    /// Data adapter for working w/ an Azure storage account
    /// </summary>
    public interface IAzureStorageAdapter
    {
        /// <summary>
        /// Initialize the Azure storage account blob container
        /// </summary>
        /// <param name="cancellationToken"></param>
        Task InitializeAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get the collection of SAS URIs for a job w/ read access
        /// </summary>
        /// <param name="job">The job document</param>
        /// <param name="contentDispostion">The desired <see cref="BlobContentDisposition"/> to include w/ the URI</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The URI</returns>
        Task<IEnumerable<string>> GetBlobReadUrisAsync(JobDocument job, BlobContentDisposition contentDispostion, CancellationToken cancellationToken);

        /// <summary>
        /// Get a SAS URI for a blob w/ write access
        /// </summary>
        /// <param name="job">The job document</param>
        /// <param name="sequence"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>The URI</returns>
        Task<string> GetBlobWriteUriAsync(JobDocument job, int sequence, CancellationToken cancellationToken);
    }

    /// <inheritdoc/>
    public class AzureStorageAdapter : IAzureStorageAdapter
    {
        private readonly BlobContainerClient _blobContainerClient;
        private readonly IUrlRouteMaskingService _urlRouteMaskingService;

        private readonly TimeSpan _sasWriteExpiration = TimeSpan.FromDays(1);
        private readonly TimeSpan _sasReadExpiration = TimeSpan.FromMinutes(15);

        /// <summary>
        /// Constructor
        /// </summary>
        public AzureStorageAdapter(BlobServiceClient blobServiceClient, IUrlRouteMaskingService urlRouteMaskingService)
        {
            _blobContainerClient = blobServiceClient.GetBlobContainerClient("jobs");
            _urlRouteMaskingService = urlRouteMaskingService;
        }

        /// <inheritdoc/>
        public Task InitializeAsync(CancellationToken cancellationToken)
        {
            return _blobContainerClient.CreateIfNotExistsAsync(cancellationToken: cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<string>> GetBlobReadUrisAsync(JobDocument job, BlobContentDisposition contentDispostion, CancellationToken cancellationToken)
        {
            var uris = new List<string>();
            var retryString = job.Retries > 0 ? $"{job.Retries}/" : string.Empty;
            var results = _blobContainerClient
                .GetBlobsAsync(BlobTraits.Metadata, prefix: $"{job.PartitionKey}/{job.Id}/{retryString}", cancellationToken: cancellationToken)
                .AsPages(default, 10);

            var index = 0;
            var datasetOptions = job.DataSetOptions?.ToList() ?? new List<DataSetOptions>();
            await foreach (var page in results)
            {
                foreach (var blob in page.Values)
                {
                    var outputFormat = datasetOptions.Count > index ? datasetOptions[index].OutputFormat : OutputFormat.csv;
                    var blobClient = _blobContainerClient.GetAppendBlobClient(blob.Name);
                    var sasUri = blobClient.GenerateSasUri(new BlobSasBuilder(BlobSasPermissions.Read, DateTime.UtcNow.Add(_sasReadExpiration))
                    {
                        ContentDisposition = contentDispostion.ToString(),
                        ContentType = outputFormat == OutputFormat.csv ? "text/csv" : $"application/{outputFormat}"
                    }).ToString();

                    sasUri = _urlRouteMaskingService.MaskBlobUrl(sasUri);

                    uris.Add(sasUri);
                    index++;
                }
            }

            return uris;
        }

        /// <inheritdoc/>
        public async Task<string> GetBlobWriteUriAsync(JobDocument job, int sequence, CancellationToken cancellationToken)
        {
            var datasetOptions = job.DataSetOptions?.ToList() ?? new List<DataSetOptions>();
            var outputFormat = datasetOptions.Count > sequence - 1 ? datasetOptions[sequence - 1].OutputFormat : OutputFormat.csv;
            var retryString = job.Retries > 0 ? $"{job.Retries}/" : string.Empty;
            var fileName = datasetOptions.ElementAtOrDefault(sequence - 1)?.FileName ?? $"results_{sequence}";

            var blobClient = _blobContainerClient.GetAppendBlobClient($"{job.PartitionKey}/{job.Id}/{retryString}{fileName}.{outputFormat}");

            await blobClient.CreateIfNotExistsAsync(
                httpHeaders: new BlobHttpHeaders() { ContentType = outputFormat == OutputFormat.csv ? "text/csv" : $"application/{outputFormat}", ContentEncoding = "UTF-8" },
                cancellationToken: cancellationToken);

            var sasUri = blobClient.GenerateSasUri(new BlobSasBuilder(BlobSasPermissions.Write | BlobSasPermissions.Read, DateTime.UtcNow.Add(_sasWriteExpiration)));

            return sasUri.ToString();
        }
    }
}
