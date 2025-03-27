using API.Accounts.Application.Features.Users.AuthToken.Validators;
using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Application.Features.Users.Models;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;
using API.Shared.Common.Constants;
using API.Shared.Common.Exceptions;

namespace API.Accounts.Application.Features.Users.Commands.ValidateAccessToken
{
    internal class ValidateAccessTokenCommandHandler : ICommandHandler<ValidateAccessTokenCommand, AuthTokenValidationViewModel>
    {
        private readonly IAuthTokenVerifier _tokenVerifier;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly ICacheSessionRepository _cacheSessionRepository;

        public ValidateAccessTokenCommandHandler(IAuthTokenVerifier tokenVerifier, IViewModelFactory viewModelFactory, ICacheSessionRepository cacheSessionRepository)
        {
            _tokenVerifier = tokenVerifier;
            _viewModelFactory = viewModelFactory;
            _cacheSessionRepository = cacheSessionRepository;
        }

        public Task<AuthTokenValidationViewModel> Handle(ValidateAccessTokenCommand request, CancellationToken cancellationToken)
        {
            var payload = _tokenVerifier.VerifyToken(request.Token);

            if (!payload.ContainsKey(APIClaimNames.TokenIdClaim) || !payload.ContainsKey(APIClaimNames.SubjectClaim))
            {
                throw new UnauthorizedException("Invalid token");
            }

            if (_cacheSessionRepository
                .GetSession(
                    payload[APIClaimNames.TokenIdClaim].ToString()!, 
                    payload[APIClaimNames.SubjectClaim].ToString()!) 
                is null)
            {
                throw new UnauthorizedException("Invalid session");
            }

            return Task.FromResult(_viewModelFactory.CreateTokenVerificationViewModel(payload));
        }
    }
}
