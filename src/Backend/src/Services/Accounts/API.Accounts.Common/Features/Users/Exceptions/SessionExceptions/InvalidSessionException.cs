using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions.SessionExceptions
{
    public class InvalidSessionException : BadRequestException
    {
        private const string MESSAGE = "Invalid Session";

        public InvalidSessionException() : base(MESSAGE)
        {
        }
    }
}
