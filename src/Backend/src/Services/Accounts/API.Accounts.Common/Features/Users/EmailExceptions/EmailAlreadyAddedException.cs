using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.EmailExceptions
{
    public class EmailAlreadyAddedException : ConflictException
    {
        private const string MESSAGE = "This email is already added";

        public EmailAlreadyAddedException() : base(MESSAGE)
        {
        }
    }
}
