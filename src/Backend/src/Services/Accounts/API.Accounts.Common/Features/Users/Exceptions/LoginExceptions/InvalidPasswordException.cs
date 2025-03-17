using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions.LoginExceptions
{
    public class InvalidPasswordException : BadRequestException
    {
        private const string MESSAGE = "Invalid password";

        public InvalidPasswordException() : base(MESSAGE)
        {
        }
    }
}
