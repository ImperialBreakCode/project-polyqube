using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.EmailExceptions
{
    public class NoVerifiedEmails : BadRequestException
    {
        private const string MESSAGE = "User has no verifed emails";

        public NoVerifiedEmails() : base(MESSAGE)
        {
        }
    }
}
