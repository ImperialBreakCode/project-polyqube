using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions
{
    public class UserDetailsAlreadyExistException : ConflictException
    {
        private const string MESSAGE = "User details already exist.";

        public UserDetailsAlreadyExistException() : base(MESSAGE)
        {
        }
    }
}
