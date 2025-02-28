using API.Shared.Common.Exceptions.Base;
using System.Net;

namespace API.Shared.Common.Exceptions
{
    public class BadRequestException : APIException
    {
        public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest)
        {
        }
    }
}
