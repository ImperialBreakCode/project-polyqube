using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions
{
    public class MissingTokenClaimsException : BadRequestException
    {
        private const string MESSAGE = "The token is missing certain claims.";

        public MissingTokenClaimsException() : base(MESSAGE)
        {
        }
    }
}
