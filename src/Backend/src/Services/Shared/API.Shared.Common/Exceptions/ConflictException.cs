using API.Shared.Common.Exceptions.Base;

namespace API.Shared.Common.Exceptions
{
    public class ConflictException : APIException
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}
