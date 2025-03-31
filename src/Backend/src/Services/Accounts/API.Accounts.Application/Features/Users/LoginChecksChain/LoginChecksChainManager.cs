using API.Accounts.Application.Features.Users.LoginChecksChain.Handlers;
using API.Accounts.Application.Features.Users.PasswordManager;
using API.Shared.Common.ChainOfResponsibility;

namespace API.Accounts.Application.Features.Users.LoginChecksChain
{
    internal class LoginChecksChainManager : ChainManager<LoginChecksData>, ILoginChecksChainManager
    {
        private readonly IPasswordManager _passwordManager;

        public LoginChecksChainManager(IPasswordManager passwordManager)
        {
            _passwordManager = passwordManager;
        }

        public ILoginChecksChainManager CheckPassword()
        {
            AddHandler(new PasswordCheck(_passwordManager));

            return this;
        }

        public ILoginChecksChainManager CheckUserLoginEligibily()
        {
            AddHandler(new CheckUserLoginEligibility());

            return this;
        }

        public ILoginChecksChainManager EnableDisabledUsers()
        {
            AddHandler(new CheckUserLoginEligibility());

            return this;
        }

        public ILoginChecksChainManager UndoSoftDeletion()
        {
            AddHandler(new CheckUserLoginEligibility());

            return this;
        }
    }
}
