using API.Shared.Common.Exceptions.Base;

namespace API.Shared.Common.Exceptions
{
    public class BadRequestException : APIException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
