using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.RefreshAuthTokens
{
    public record RefreshAuthTokensCommand(string RefreshToken) : ICommand<AuthTokensViewModel>;
}
