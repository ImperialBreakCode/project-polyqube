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
using API.Shared.Domain.CacheEntities.Accounts;

namespace API.Accounts.Application.Features.Users.Commands.RefreshAuthTokens
{
    internal class RefreshAuthTokensCommandHandler : ICommandHandler<RefreshAuthTokensCommand, AuthTokensViewModel>
    {
        private readonly IAuthTokenIssuer _authTokenIssuer;
        private readonly IAuthTokenVerifier _authTokenVerifier;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly ICacheSessionRepository _cacheSessionRepository;
        private readonly ISessionAccessInfoRepository _sessionAccessInfoRepository;

        public RefreshAuthTokensCommandHandler(
            IAuthTokenIssuer authTokenIssuer,
            IAuthTokenVerifier authTokenVerifier,
            IUnitOfWork unitOfWork,
            IViewModelFactory viewModelFactory,
            ICacheSessionRepository cacheSessionRepository,
            ISessionAccessInfoRepository sessionAccessInfoRepository)
        {
            _authTokenIssuer = authTokenIssuer;
            _authTokenVerifier = authTokenVerifier;
            _unitOfWork = unitOfWork;
            _viewModelFactory = viewModelFactory;
            _cacheSessionRepository = cacheSessionRepository;
            _sessionAccessInfoRepository = sessionAccessInfoRepository;
        }

        public Task<AuthTokensViewModel> Handle(RefreshAuthTokensCommand request, CancellationToken cancellationToken)
        {
            var refreshPayload = _authTokenVerifier.VerifyToken(request.RefreshToken);

            if (!refreshPayload.ContainsKey(APIClaimNames.SubjectClaim) 
                || !refreshPayload.ContainsKey(APIClaimNames.TokenIdClaim)
                || !refreshPayload.ContainsKey(APIClaimNames.SessionId))
            {
                throw new MissingTokenClaimsException();
            }

            var user = _unitOfWork.UserRepository.GetActiveEntityById(refreshPayload[APIClaimNames.SubjectClaim].ToString()!);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var session = _cacheSessionRepository.GetSession(refreshPayload[APIClaimNames.SessionId].ToString()!, user.Id);
            if (session is null)
            {
                throw new InvalidSessionException();
            }

            if (session.RefreshTokenId != refreshPayload[APIClaimNames.TokenIdClaim].ToString()!)
            {
                throw new InvalidRefreshToken();
            }

            var userRoles = _unitOfWork.UserRepository.GetUserRoles(user.Id).Select(x => x.Role.RoleName).ToArray();

            var accessTokenResult = _authTokenIssuer.IssueAccessToken(user, userRoles);
            var newRefreshTokenResult = _authTokenIssuer.IssueRefreshToken(user);

            _cacheSessionRepository.DeleteSession(refreshPayload[APIClaimNames.SessionId].ToString()!, user.Id);
            _cacheSessionRepository.SetSession(
                UserSession.Create(
                    newRefreshTokenResult.SessionId,
                    user.Id, 
                    newRefreshTokenResult.TokenId,
                    accessTokenResult.TokenId,
                    newRefreshTokenResult.Expiration
                    ));

            _sessionAccessInfoRepository.DeleteSessionAccess(refreshPayload[APIClaimNames.SessionId].ToString()!, user.Id);
            _sessionAccessInfoRepository.SetSessionAccess(
                SessionAccessInfo.Create(
                    [],
                    user.Id,
                    newRefreshTokenResult.SessionId,
                    newRefreshTokenResult.Expiration
                    ));

            return Task.FromResult(_viewModelFactory.CreateAuthTokensViewModel(accessTokenResult.Token, newRefreshTokenResult.Token));
        }
    }
}
