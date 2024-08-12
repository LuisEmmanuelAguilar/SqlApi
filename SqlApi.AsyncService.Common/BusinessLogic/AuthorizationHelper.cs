using Company.Core.WebService.Contracts.Exceptions;
using Company.Core.WebService.Contracts;
using SqlApi.AsyncService.Common.DataAccess.Models;
using Company.Core.WebService.AspNetCore.Authorization;
using System.Text.Json;

namespace SqlApi.AsyncService.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class AuthorizationHelper
    {
        /// <summary>
        /// SAS scope granted to consumers of the nsa-async service
        /// </summary>
        public const string ConsumerScope = "consumer";

        /// <summary>
        /// SAS scope granted to async SQL API back-end services
        /// </summary>
        public const string BackendScope = "backend";

        /// <summary>
        /// Authorize the current request's access to the requested job
        /// </summary>
        /// <param name="jobDocument"></param>
        /// <param name="requestContext"></param>
        /// <exception cref="ForbiddenV2Exception"></exception>
        public static void AuthorizeJobAccess(JobDocument jobDocument, IRequestContext requestContext)
        {
            switch (requestContext.RequestAuthorizationType)
            {
                case RequestAuthorizationType.CompanyId:
                    if (!requestContext.AuthenticationUserId.Equals(jobDocument.UserId, StringComparison.OrdinalIgnoreCase))
                    {
                        throw new ForbiddenV2Exception();
                    }
                    break;

                case RequestAuthorizationType.SecurityAuthorizationService:
                    if (requestContext.HasServiceAuthorizationScope(ConsumerScope))
                    {
                        if (!requestContext.TrustedCallerClientName.Equals(jobDocument.Audience, StringComparison.OrdinalIgnoreCase))
                        {
                            throw new ForbiddenV2Exception();
                        }
                    }
                    else if (!requestContext.HasServiceAuthorizationScope(BackendScope))
                    {
                        throw new ForbiddenV2Exception();
                    }
                    break;

                default:
                    throw new ForbiddenV2Exception();
            }
        }
    }
}
