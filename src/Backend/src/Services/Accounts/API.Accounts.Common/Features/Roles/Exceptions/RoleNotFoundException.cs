using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Roles.Exceptions
{
    public class RoleNotFoundException : NotFoundException
    {
        private const string MESSAGE = "Role not found.";

        public RoleNotFoundException() : base(MESSAGE)
        {
        }
    }
}
