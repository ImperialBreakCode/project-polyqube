using API.Shared.Common.Exceptions;

namespace API.Accounts.Common.Features.Users.Exceptions.ModuleAuthExceptions
{
    public class ModuleAuthNotFoundException : NotFoundException
    {
        private const string MESSAGE = "Module auth data not found"; 
        public ModuleAuthNotFoundException() : base(MESSAGE)
        {
        }
    }
}
