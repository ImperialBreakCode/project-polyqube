using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions.LoginExceptions
{
    public class UserLockedOutException : BadRequestException
    {
        private const string MESSAGE = "Cannot login. User is locked.";

        public UserLockedOutException() : base(MESSAGE)
        {
        }
    }
}
