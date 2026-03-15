using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.RevokeSession
{
    public record RevokeSessionCommand(string UserId, string SessionId) : ICommand;
}
