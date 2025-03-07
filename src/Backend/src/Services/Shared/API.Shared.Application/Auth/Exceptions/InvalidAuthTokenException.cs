using API.Shared.Common.Exceptions.Base;
using System.Net;

namespace API.Shared.Application.Auth.Exceptions
{
    public class InvalidAuthTokenException : APIException
    {
        public InvalidAuthTokenException(string message) : base(message, HttpStatusCode.InternalServerError)
        {
        }
    }
}
