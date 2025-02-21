using API.Shared.Common.Exceptions;

namespace API.Accounts.Domain.Exceptions.RoleExceptions
{
    public class RoleAlreadyAssignedException : BadRequestException
    {
        private const string MESSAGE = "Role already assigned to user";

        public RoleAlreadyAssignedException() : base(MESSAGE)
        {
        }
    }
}
