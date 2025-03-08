﻿using API.Accounts.Application.Features.Users.Models;

namespace API.Accounts.Application.Features.Users.Factories
{
    internal class ViewModelFactory : IViewModelFactory
    {
        public LoginViewModel CreateLoginViewModel(string accessToken)
        {
            return new LoginViewModel(accessToken);
        }
    }
}
