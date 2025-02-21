using API.Shared.Common.Exceptions;

namespace API.Accounts.Domain.Exceptions.EmailExceptions
{
    public class CannotRemoveEmailException : BadRequestException
    {
        private const string MESSAGE = "Cannot remove. At least one email should exist";

        public CannotRemoveEmailException() : base(MESSAGE)
        {
        }
    }
}
