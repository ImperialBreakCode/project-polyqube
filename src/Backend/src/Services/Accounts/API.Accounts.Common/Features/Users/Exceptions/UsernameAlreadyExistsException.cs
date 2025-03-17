using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions
{
    public class UsernameAlreadyExistsException : ConflictException
    {
        private const string MESSAGE = "Username already taken";

        public UsernameAlreadyExistsException() : base(MESSAGE)
        {
        }
    }
}
