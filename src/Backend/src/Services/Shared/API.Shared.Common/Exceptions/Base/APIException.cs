using System.Net;

namespace API.Shared.Common.Exceptions.Base
{
    public class APIException(string message, HttpStatusCode statusCode) : Exception(message)
    {
        public HttpStatusCode StatusCode { get; init; } = statusCode;
    }
}
