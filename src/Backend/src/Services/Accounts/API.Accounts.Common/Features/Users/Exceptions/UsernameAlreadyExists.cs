using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions
{
    public class UsernameAlreadyExists : ConflictException
    {
        private const string MESSAGE = "Username already taken";

        public UsernameAlreadyExists() : base(MESSAGE)
        {
        }
    }
}
