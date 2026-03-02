using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions
{
    public class InvalidRefreshToken: BadRequestException
    {
        private const string MESSAGE = "Invalid Refresh Token";

        public InvalidRefreshToken() : base(MESSAGE)
        {
        } 
    }
}
