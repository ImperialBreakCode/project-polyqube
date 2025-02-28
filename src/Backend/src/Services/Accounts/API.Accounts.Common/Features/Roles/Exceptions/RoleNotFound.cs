using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Roles.Exceptions
{
    public class RoleNotFound : NotFoundException
    {
        private const string MESSAGE = "Role not found.";

        public RoleNotFound() : base(MESSAGE)
        {
        }
    }
}
