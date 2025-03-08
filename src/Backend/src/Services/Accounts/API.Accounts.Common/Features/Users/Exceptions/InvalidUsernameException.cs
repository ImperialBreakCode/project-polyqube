using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions
{
    public class InvalidUsernameException : BadRequestException
    {
        private const string MESSAGE = "Invalid username";

        public InvalidUsernameException() : base(MESSAGE)
        {
        }
    }
}
