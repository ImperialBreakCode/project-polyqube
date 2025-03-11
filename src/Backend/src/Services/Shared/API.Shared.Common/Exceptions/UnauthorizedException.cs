using API.Shared.Common.Exceptions.Base;
using System.Net;

namespace API.Shared.Common.Exceptions
{
    public class UnauthorizedException : APIException
    {
        public UnauthorizedException(string message) : base(message, HttpStatusCode.Unauthorized)
        {
        }
    }
}
