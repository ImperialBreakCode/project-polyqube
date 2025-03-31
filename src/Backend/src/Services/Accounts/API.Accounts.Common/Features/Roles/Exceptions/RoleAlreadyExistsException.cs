using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Roles.Exceptions
{
    public class RoleAlreadyExistsException : ConflictException
    {
        private const string MESSAGE = "Role already exists";

        public RoleAlreadyExistsException() : base(MESSAGE)
        {
        }
    }
}
