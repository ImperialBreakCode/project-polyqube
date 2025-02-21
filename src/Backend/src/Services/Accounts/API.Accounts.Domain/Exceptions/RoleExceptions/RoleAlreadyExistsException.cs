using API.Shared.Common.Exceptions;

namespace API.Accounts.Domain.Exceptions.RoleExceptions
{
    public class RoleAlreadyExistsException : ConflictException
    {
        private const string MESSAGE = "Role already exists";

        public RoleAlreadyExistsException() : base(MESSAGE)
        {
        }
    }
}
