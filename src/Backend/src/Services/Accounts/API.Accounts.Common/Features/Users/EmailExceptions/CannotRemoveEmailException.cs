using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.EmailExceptions
{
    public class CannotRemoveEmailException : BadRequestException
    {
        private const string MESSAGE = "Cannot remove. At least one email should exist";

        public CannotRemoveEmailException() : base(MESSAGE)
        {
        }
    }
}
