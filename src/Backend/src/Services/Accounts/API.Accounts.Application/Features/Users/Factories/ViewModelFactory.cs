using API.Accounts.Application.Features.Users.Models;

namespace API.Accounts.Application.Features.Users.Factories
{
    internal class ViewModelFactory : IViewModelFactory
    {
        public AuthTokensViewModel CreateAuthTokensViewModel(string accessToken, string refreshToken)
        {
            return new AuthTokensViewModel(accessToken, refreshToken);
        }

        public AuthTokenValidationViewModel CreateTokenVerificationViewModel(IDictionary<string, object> payload)
        {
            return new AuthTokenValidationViewModel(payload);
        }
    }
}
