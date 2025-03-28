using API.Shared.Common.ChainOfResponsibility;

namespace API.Accounts.Application.Features.Users.LoginChecksChain
{
    internal interface ILoginChecksChainManager : IChainManager<LoginChecksData>
    {
        ILoginChecksChainManager CheckUserLoginEligibily();
        ILoginChecksChainManager EnableDisabledUsers();
        ILoginChecksChainManager UndoSoftDeletion();
        ILoginChecksChainManager CheckPassword();
    }
}
