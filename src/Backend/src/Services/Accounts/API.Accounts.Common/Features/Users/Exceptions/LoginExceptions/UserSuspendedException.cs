using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions.LoginExceptions
{
    public class UserSuspendedException : BadRequestException
    {
        private const string MESSAGE = "Cannot loggin. User suspended.";

        public UserSuspendedException() : base(MESSAGE)
        {
        }
    }
}
