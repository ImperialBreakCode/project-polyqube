using API.Shared.Common.Exceptions.Base;

namespace API.Shared.Common.Exceptions
{
    public class NotFoundException : APIException
    {
        public NotFoundException(string message) : base(message, System.Net.HttpStatusCode.NotFound)
        {
        }
    }
}
