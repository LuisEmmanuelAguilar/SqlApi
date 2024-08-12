namespace SqlApi.AsyncService.Common.DataAccess.StorageProxy
{
    /// <summary>
    /// A service for masking sas urls for a storage account to be used with the azure storage proxy
    /// </summary>
    public interface IUrlRouteMaskingService
    {
        /// <summary>
        /// Converts a blob SAS Url to the format required by the proxy
        /// </summary>
        string MaskBlobUrl(string azureBlobUrl);
    }
}
