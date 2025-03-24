using API.Accounts.Common.Features.Users.Exceptions.LoginExceptions;
using API.Shared.Common.ChainOfResponsibility;

namespace API.Accounts.Application.Features.Users.LoginChecksChain.Handlers
{
    internal class CheckUserLoginEligibility : ChainHandler<LoginChecksData>
    {
        protected override Task Execute(LoginChecksData data)
        {
            if (data.User.LockedOut)
            {
                throw new UserLockedOutException();
            }

            if (data.User.Suspended)
            {
                throw new UserSuspendedException();
            }

            if (data.User.SystemLock)
            {
                throw new UserInSystemLockException();
            }

            return Task.CompletedTask;
        }
    }
}
