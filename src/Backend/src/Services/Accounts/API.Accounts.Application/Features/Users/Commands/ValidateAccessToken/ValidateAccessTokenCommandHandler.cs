using API.Accounts.Application.Features.Users.AuthToken.Validators;
using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.ValidateAccessToken
{
    internal class ValidateAccessTokenCommandHandler : ICommandHandler<ValidateAccessTokenCommand, AuthTokenValidationViewModel>
    {
        private readonly IAuthTokenVerifier _tokenVerifier;
        private readonly IViewModelFactory _viewModelFactory;

        public ValidateAccessTokenCommandHandler(IAuthTokenVerifier tokenVerifier, IViewModelFactory viewModelFactory)
        {
            _tokenVerifier = tokenVerifier;
            _viewModelFactory = viewModelFactory;
        }

        public Task<AuthTokenValidationViewModel> Handle(ValidateAccessTokenCommand request, CancellationToken cancellationToken)
        {
            var payload = _tokenVerifier.VerifyToken(request.Token);

            return Task.FromResult(_viewModelFactory.CreateTokenVerificationViewModel(payload));
        }
    }
}
