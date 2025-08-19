using API.Accounts.Application.Features.Users.AuthToken.Issuer;
using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Application.Features.Users.LoginChecksChain;
using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Common.Features.Users.Exceptions.LoginExceptions;
using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Accounts.Domain.CacheEntities;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.LoginUser
{
    internal class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, AuthTokensViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthTokenIssuer _authTokenIssuer;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly ICacheSessionRepository _sessionRepository;
        private readonly ILoginChecksChainManager _loginChecksManager;

        public LoginUserCommandHandler(
            IUnitOfWork unitOfWork,
            IAuthTokenIssuer authTokenIssuer,
            IViewModelFactory viewModelFactory,
            ICacheSessionRepository sessionRepository,
            ILoginChecksChainManager loginChecksManager)
        {
            _unitOfWork = unitOfWork;
            _authTokenIssuer = authTokenIssuer;
            _viewModelFactory = viewModelFactory;
            _sessionRepository = sessionRepository;
            _loginChecksManager = loginChecksManager;
        }

        public async Task<AuthTokensViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            User? user = _unitOfWork.UserRepository.GetUserByUsername(request.Username, true);

            if (user is null)
            {
                throw new InvalidUsernameException();
            }

            await _loginChecksManager
                    .CheckUserLoginEligibily()
                    .EnableDisabledUsers()
                    .UndoSoftDeletion()
                    .CheckPassword()
                    .ExecuteChain(LoginChecksData.Create(user, request.Password));

            _unitOfWork.Save();

            var userRoles = _unitOfWork.UserRepository.GetUserRoles(user.Id).Select(x => x.Role.RoleName).ToArray();
            var accessTokenResult = _authTokenIssuer.IssueAccessToken(user, userRoles);
            var refreshTokenResult = _authTokenIssuer.IssueRefreshToken(user);

            _sessionRepository.SetSession(
                UserSession.Create(
                    refreshTokenResult.TokenId, 
                    user.Id,
                    refreshTokenResult.Expiration
                    ));

            return _viewModelFactory.CreateAuthTokensViewModel(accessTokenResult.Token, refreshTokenResult.Token);
        }
    }
}
