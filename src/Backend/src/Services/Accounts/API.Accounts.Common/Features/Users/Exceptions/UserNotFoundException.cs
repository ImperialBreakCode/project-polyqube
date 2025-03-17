using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        private const string MESSAGE = "User not found";

        public UserNotFoundException() : base(MESSAGE)
        {
        }
    }
}
