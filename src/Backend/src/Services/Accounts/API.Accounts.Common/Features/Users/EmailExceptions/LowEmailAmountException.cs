using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.EmailExceptions
{
    public class LowEmailAmountException : BadRequestException
    {
        private const string MESSAGE = "At least one email should be added";
        public LowEmailAmountException() : base(MESSAGE)
        {
        }
    }
}
