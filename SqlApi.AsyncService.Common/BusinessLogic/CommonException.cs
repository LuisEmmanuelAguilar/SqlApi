using Company.Core.WebService.Contracts.Exceptions;
using SqlApi.AsyncService.Common.DataAccess.Models;
using SqlApi.AsyncService.Common.Models;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace SqlApi.AsyncService.Common.BusinessLogic
{
    /// <summary>
    /// Some common exception-related behavior
    /// </summary>
    public static class CommonExceptions
    {
        /// <summary>
        /// Throw a <see cref="ConflictV2Exception"/> configured to indicate an UnexpectedStatus conflict.
        /// </summary>
        /// <param name="currentStatus"></param>
        /// <param name="requestedStatus"></param>
        /// <exception cref="ConflictV2Exception"></exception>
        public static void ThrowUnexpectedStatusConflict(JobStatus currentStatus, JobStatus? requestedStatus = null)
        {
            throw new ConflictV2Exception($"Unexpected status change request, current status = {currentStatus}{(requestedStatus.HasValue ? $", requested status = {requestedStatus}" : string.Empty)}")
            {
                Values = new Dictionary<string, object>
                {
                    { "ConflictType", "UnexpectedStatus" },
                    { "CurrentStatus", currentStatus.ToString() }
                }
            };
        }

        /// <summary>
        /// Validate the request id and throw an exception if invalid.
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="jobDocument"></param>
        /// <param name="logger"></param>
        /// <exception cref="InvalidInputV2Exception"></exception>
        public static void ValidateRequestId(string requestId, JobDocument jobDocument, ILogger logger)
        {
            if (requestId != null)
            {
                if (!int.TryParse(requestId, out int intRequestId))
                {
                    throw new InvalidInputV2Exception<HttpStatusCode>(HttpStatusCode.BadRequest, "Invalid request_id, please provide a valid int.");
                }
                if (jobDocument.Retries != intRequestId)
                {
                    ThrowRequestIdMismatchConflict(intRequestId, jobDocument.Retries, logger);
                }
            }
        }

        private static void ThrowRequestIdMismatchConflict(int incomingRequestId, int jobDocumentRequestId, ILogger logger)
        {
            logger.LogError("Request id mismatch (incoming = {IncomingRequestId}, job document = {JobDocumentRequestId})", incomingRequestId, jobDocumentRequestId);

            throw new ConflictV2Exception("Request id mismatch")
            {
                Values = new Dictionary<string, object>
                {
                    { "ConflictType", "RequestIdMismatch" }
                }
            };
        }
    }
}
