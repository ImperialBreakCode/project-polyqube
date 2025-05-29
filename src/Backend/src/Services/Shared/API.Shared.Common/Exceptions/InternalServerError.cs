using API.Shared.Common.Exceptions.Base;
using System.Net;

namespace API.Shared.Common.Exceptions
{
    public class InternalServerError(string message = "Server error occured.") : APIException(message, HttpStatusCode.InternalServerError)
    {
    }
}
