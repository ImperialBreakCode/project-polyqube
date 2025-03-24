using API.Accounts.Application.Features.Users.PasswordManager;
using API.Accounts.Common.Features.Users.Exceptions.LoginExceptions;
using API.Shared.Common.ChainOfResponsibility;

namespace API.Accounts.Application.Features.Users.LoginChecksChain.Handlers
{
    internal class PasswordCheck : ChainHandler<LoginChecksData>
    {
        private readonly IPasswordManager _passwordManager;

        public PasswordCheck(IPasswordManager passwordManager)
        {
            _passwordManager = passwordManager;
        }

        protected override Task Execute(LoginChecksData data)
        {
            if (!_passwordManager.VerifyPassword(data.RequestPassword, data.User.PasswordHash))
            {
                throw new InvalidPasswordException();
            }

            return Task.CompletedTask;
        }
    }
}
