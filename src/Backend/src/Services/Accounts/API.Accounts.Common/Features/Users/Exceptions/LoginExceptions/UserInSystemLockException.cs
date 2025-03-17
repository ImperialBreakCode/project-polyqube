using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions.LoginExceptions
{
    public class UserInSystemLockException : BadRequestException
    {
        private const string MESSAGE = "Cannot loggin because user is temporary locked. Try again later.";

        public UserInSystemLockException() : base(MESSAGE)
        {
        }
    }
}
