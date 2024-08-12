using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;

namespace SqlApi.AsyncService.Common.DataAccess.StorageProxy
{
    /// <inheritdoc/>
    public class UrlRouteMaskingService : IUrlRouteMaskingService
    {
        private readonly Regex _azureBlobStorageRegex = new($"https://(?<accountName>.*).blob.core.windows.net/(?<url>.*)");
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _hostEnvironment;

        /// <summary>
        /// Instantiates the UrlRouteMaskingService
        /// </summary>
        public UrlRouteMaskingService(IHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            _configuration = configuration;
            _hostEnvironment = hostEnvironment;
        }

        /// <inheritdoc/>
        public string MaskBlobUrl(string azureBlobUrl)
        {
            var matchingGroups = _azureBlobStorageRegex.Matches(azureBlobUrl);
            var match = matchingGroups.FirstOrDefault();

            if (_hostEnvironment.IsDevelopment())
            {
                return match != null ? $"https://localhost:5222/blobs/{match.Groups["accountName"]}/{match.Groups["url"]}" : null;
            }

            var zone = _configuration.GetValue<string>("EngSys:Zone").Replace("-", string.Empty); ;
            return match != null ? $"https://nsa-{zone}.app.Company.net/async/blobs/{match.Groups["accountName"]}/{match.Groups["url"]}" : null;
        }
    }
}
