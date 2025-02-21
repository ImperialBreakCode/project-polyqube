using API.Shared.Common.Exceptions;

namespace API.Accounts.Domain.Exceptions.UserExceptions
{
    public class UsernameAlreadyExists : ConflictException
    {
        private const string MESSAGE = "Username already taken";

        public UsernameAlreadyExists() : base(MESSAGE)
        {
        }
    }
}
