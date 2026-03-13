using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.EmailExceptions
{
    public class EmailNotVerified : BadRequestException
    {
        private const string MESSAGE = "Email is not verified.";
        public EmailNotVerified() : base(MESSAGE)
        {
        }
    }
}
