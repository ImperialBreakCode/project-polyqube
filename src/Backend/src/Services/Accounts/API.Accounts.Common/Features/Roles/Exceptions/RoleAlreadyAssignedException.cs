using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Roles.Exceptions
{
    public class RoleAlreadyAssignedException : BadRequestException
    {
        private const string MESSAGE = "Role already assigned to user";

        public RoleAlreadyAssignedException() : base(MESSAGE)
        {
        }
    }
}
