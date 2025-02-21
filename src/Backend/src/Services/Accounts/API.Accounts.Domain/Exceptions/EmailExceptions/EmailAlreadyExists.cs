using API.Shared.Common.Exceptions;

namespace API.Accounts.Domain.Exceptions.EmailExceptions
{
    public class EmailAlreadyExists : ConflictException
    {
        private const string MESSAGE = "Email already exists";

        public EmailAlreadyExists() : base(MESSAGE)
        {
        }
    }
}
