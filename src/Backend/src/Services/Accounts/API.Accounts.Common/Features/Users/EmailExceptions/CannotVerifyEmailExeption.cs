using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.EmailExceptions
{
    public class CannotVerifyEmailExeption : BadRequestException
    {
        private const string MESSAGE = "Could not verify user's email";

        public CannotVerifyEmailExeption() : base(MESSAGE)
        {
        }
    }
}
