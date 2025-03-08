﻿using API.Accounts.Application.Features.Users.AuthTokenIssuer;
using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Application.Features.Users.PasswordManager;
using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.LoginUser
{
    internal class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, LoginViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthTokenIssuer _authTokenIssuer;
        private readonly IPasswordManager _passwordManager;
        private readonly IViewModelFactory _viewModelFactory;

        public LoginUserCommandHandler(IUnitOfWork unitOfWork, IAuthTokenIssuer authTokenIssuer, IPasswordManager passwordManager, IViewModelFactory viewModelFactory)
        {
            _unitOfWork = unitOfWork;
            _authTokenIssuer = authTokenIssuer;
            _passwordManager = passwordManager;
            _viewModelFactory = viewModelFactory;
        }

        public Task<LoginViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User? user = _unitOfWork.UserRepository.GetUserByUsername(request.Username);

            if (user is null)
            {
                throw new InvalidUsernameException();
            }

            if (!_passwordManager.VerifyPassword(request.Password, user.PasswordHash))
            {
                throw new InvalidPasswordException();
            }

            var userRoles = _unitOfWork.UserRepository.GetUserRoles(user.Id).Select(x => x.Role.RoleName).ToArray();
            string token = _authTokenIssuer.IssueToken(user, userRoles);

            return Task.FromResult(_viewModelFactory.CreateLoginViewModel(token));
        }
    }
}
