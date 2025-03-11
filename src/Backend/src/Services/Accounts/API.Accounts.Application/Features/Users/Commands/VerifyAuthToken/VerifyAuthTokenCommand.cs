using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.VerifyAuthToken
{
    public record VerifyAuthTokenCommand(string Token) : ICommand<TokenVerificationViewModel>;
}
