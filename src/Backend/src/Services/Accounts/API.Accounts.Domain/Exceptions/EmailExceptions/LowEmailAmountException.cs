using API.Shared.Common.Exceptions;

namespace API.Accounts.Domain.Exceptions.EmailExceptions
{
    public class LowEmailAmountException : BadRequestException
    {
        private const string MESSAGE = "At least one email should be added";
        public LowEmailAmountException() : base(MESSAGE)
        {
        }
    }
}
