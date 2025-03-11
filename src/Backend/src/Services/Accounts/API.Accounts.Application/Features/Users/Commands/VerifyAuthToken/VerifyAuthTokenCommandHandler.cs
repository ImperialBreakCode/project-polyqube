using API.Accounts.Application.Features.Users.AuthToken;
using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.VerifyAuthToken
{
    internal class VerifyAuthTokenCommandHandler : ICommandHandler<VerifyAuthTokenCommand, TokenVerificationViewModel>
    {
        private readonly IAuthTokenVerifier _tokenVerifier;
        private readonly IViewModelFactory _viewModelFactory;

        public VerifyAuthTokenCommandHandler(IAuthTokenVerifier tokenVerifier, IViewModelFactory viewModelFactory)
        {
            _tokenVerifier = tokenVerifier;
            _viewModelFactory = viewModelFactory;
        }

        public Task<TokenVerificationViewModel> Handle(VerifyAuthTokenCommand request, CancellationToken cancellationToken)
        {
            var payload = _tokenVerifier.VerifyToken(request.Token);

            return Task.FromResult(_viewModelFactory.CreateTokenVerificationViewModel(payload));
        }
    }
}
