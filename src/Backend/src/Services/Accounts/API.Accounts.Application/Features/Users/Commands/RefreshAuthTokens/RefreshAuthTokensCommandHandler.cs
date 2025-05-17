using API.Accounts.Application.Features.Users.AuthToken.Issuer;
using API.Accounts.Application.Features.Users.AuthToken.Validators;
using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Common.Features.Users.Exceptions.SessionExceptions;
using API.Accounts.Domain;
using API.Accounts.Domain.CacheEntities;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;
using API.Shared.Common.Constants;

namespace API.Accounts.Application.Features.Users.Commands.RefreshAuthTokens
{
    internal class RefreshAuthTokensCommandHandler : ICommandHandler<RefreshAuthTokensCommand, AuthTokensViewModel>
    {
        private readonly IAuthTokenIssuer _authTokenIssuer;
        private readonly IAuthTokenVerifier _authTokenVerifier;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly ICacheSessionRepository _cacheSessionRepository;

        public RefreshAuthTokensCommandHandler(
            IAuthTokenIssuer authTokenIssuer,
            IAuthTokenVerifier authTokenVerifier,
            IUnitOfWork unitOfWork,
            IViewModelFactory viewModelFactory,
            ICacheSessionRepository cacheSessionRepository)
        {
            _authTokenIssuer = authTokenIssuer;
            _authTokenVerifier = authTokenVerifier;
            _unitOfWork = unitOfWork;
            _viewModelFactory = viewModelFactory;
            _cacheSessionRepository = cacheSessionRepository;
        }

        public Task<AuthTokensViewModel> Handle(RefreshAuthTokensCommand request, CancellationToken cancellationToken)
        {
            var refreshPayload = _authTokenVerifier.VerifyToken(request.RefreshToken);

            if (!refreshPayload.ContainsKey(APIClaimNames.SubjectClaim) 
                || !refreshPayload.ContainsKey(APIClaimNames.TokenIdClaim))
            {
                throw new MissingTokenClaimsException();
            }

            var user = _unitOfWork.UserRepository.GetActiveEntityById(refreshPayload[APIClaimNames.SubjectClaim].ToString()!);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            if (_cacheSessionRepository
                .GetSession(refreshPayload[APIClaimNames.TokenIdClaim].ToString()!, user.Id) is null)
            {
                throw new InvalidSessionException();
            }

            var userRoles = _unitOfWork.UserRepository.GetUserRoles(user.Id).Select(x => x.Role.RoleName).ToArray();

            var accessTokenResult = _authTokenIssuer.IssueAccessToken(user, userRoles);
            var newRefreshTokenResult = _authTokenIssuer.IssueRefreshToken(user);

            _cacheSessionRepository.DeleteSession(refreshPayload[APIClaimNames.TokenIdClaim].ToString()!, user.Id);
            _cacheSessionRepository.SetSession(
                UserSession.Create(
                    newRefreshTokenResult.TokenId,
                    user.Id, 
                    newRefreshTokenResult.Expiration
                    ));

            return Task.FromResult(_viewModelFactory.CreateAuthTokensViewModel(accessTokenResult.Token, newRefreshTokenResult.Token));
        }
    }
}
