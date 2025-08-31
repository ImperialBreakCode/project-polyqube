using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions
{
    public class UserDetailsNotFoundException : NotFoundException
    {
        private const string MESSAGE = "User details not found.";

        public UserDetailsNotFoundException() : base(MESSAGE)
        {
        }
    }
}
