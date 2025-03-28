using API.Shared.Common.ChainOfResponsibility;

namespace API.Accounts.Application.Features.Users.LoginChecksChain.Handlers
{
    internal class UndoSoftDeletion : ChainHandler<LoginChecksData>
    {
        protected override Task Execute(LoginChecksData data)
        {
            if (data.User.DeletedAt is not null)
            {
                data.User.UndoSoftDelete();
            }

            return Task.CompletedTask;
        }
    }
}
