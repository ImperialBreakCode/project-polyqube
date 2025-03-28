using API.Shared.Common.ChainOfResponsibility;

namespace API.Accounts.Application.Features.Users.LoginChecksChain.Handlers
{
    internal class EnableDisabledUser : ChainHandler<LoginChecksData>
    {
        protected override Task Execute(LoginChecksData data)
        {
            if (data.User.Disabled)
            {
                data.User.SetDisabled(false);
            }

            return Task.CompletedTask;
        }
    }
}
