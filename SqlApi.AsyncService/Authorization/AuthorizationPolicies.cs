using Company.Core.WebService.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace SqlApi.AsyncService.Authorization
{
    /// <summary>
    /// Authorization policy name constants and extension methods for adding policies to the <see cref="IServiceCollection"/>
    /// </summary>
    public static class AuthorizationPolicies
    {
        /// <summary>
        /// Policy used for supportal endpoints
        /// </summary>
        public const string SupportalPolicy = "Supportal";

        /// <summary>
        /// Allow list of users for supportal endpoints
        /// </summary>
        public static readonly string[] SupportalAllowList = new[]
        {
            "28989556-aadb-4bff-b6df-1ecab94fe21a", // Juan
            "b20a5147-7209-4b05-8e36-3416f80c6c8a", // Michael
        };

        /// <summary>
        /// Add authorization policies so they can be referenced from <see cref="AuthorizeAttribute"/>s
        /// </summary>
        public static IServiceCollection AddAuthorizationPolicies(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddAuthorization(authOptions =>
            {
                authOptions
                    .AddPolicy(SupportalPolicy, policyBuilder => policyBuilder.AddRequirements(new AuthenticationUserIdWhitelistRequirement(SupportalAllowList)));
            });
        }
    }
}
