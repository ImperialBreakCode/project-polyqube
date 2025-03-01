using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.EmailExceptions
{
    public class EmailAlreadyExists : ConflictException
    {
        private const string MESSAGE = "Email already exists";

        public EmailAlreadyExists() : base(MESSAGE)
        {
        }
    }
}
