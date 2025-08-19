using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions
{
    public class CannotDeleteUserException : BadRequestException
    {
        private const string MESSAGE = "Cannot delete user. Invalid request.";

        public CannotDeleteUserException() : base(MESSAGE)
        {
        }
    }
}
