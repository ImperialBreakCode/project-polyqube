using API.Accounts.Application.Features.Users.Models;

namespace API.Accounts.Application.Features.Users.Factories
{
    internal interface IViewModelFactory
    {
        AuthTokensViewModel CreateAuthTokensViewModel(string accessToken, string refreshToken);
        AuthTokenValidationViewModel CreateTokenVerificationViewModel(IDictionary<string, object> payload);
    }
}
