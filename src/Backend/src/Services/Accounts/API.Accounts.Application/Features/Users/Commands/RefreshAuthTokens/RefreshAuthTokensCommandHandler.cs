using API.Accounts.Application.Features.Users.AuthToken.Issuer;
using API.Accounts.Application.Features.Users.AuthToken.Validators;
using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Common.Features.Users.Exceptions;
using API.Accounts.Domain;
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

        public RefreshAuthTokensCommandHandler(
            IAuthTokenIssuer authTokenIssuer,
            IAuthTokenVerifier authTokenVerifier,
            IUnitOfWork unitOfWork,
            IViewModelFactory viewModelFactory)
        {
            _authTokenIssuer = authTokenIssuer;
            _authTokenVerifier = authTokenVerifier;
            _unitOfWork = unitOfWork;
            _viewModelFactory = viewModelFactory;
        }

        public Task<AuthTokensViewModel> Handle(RefreshAuthTokensCommand request, CancellationToken cancellationToken)
        {
            var refreshPayload = _authTokenVerifier.VerifyToken(request.RefreshToken);

            if (!refreshPayload.ContainsKey(APIClaimNames.UsernameClaim))
            {
                throw new MissingTokenClaimsException();
            }

            var user = _unitOfWork.UserRepository.GetUserByUsername(refreshPayload[APIClaimNames.UsernameClaim].ToString());
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            var userRoles = _unitOfWork.UserRepository.GetUserRoles(user.Id).Select(x => x.Role.RoleName).ToArray();

            var accessToken = _authTokenIssuer.IssueAccessToken(user, userRoles);
            var newRefreshToken = _authTokenIssuer.IssueRefreshToken(user);

            return Task.FromResult(_viewModelFactory.CreateAuthTokensViewModel(accessToken, newRefreshToken));
        }
    }
}
