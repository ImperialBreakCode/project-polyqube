using API.Accounts.Application.Features.Users.Models;

namespace API.Accounts.Application.Features.Users.Factories
{
    internal interface IViewModelFactory
    {
        LoginViewModel CreateLoginViewModel(string accessToken);
    }
}
