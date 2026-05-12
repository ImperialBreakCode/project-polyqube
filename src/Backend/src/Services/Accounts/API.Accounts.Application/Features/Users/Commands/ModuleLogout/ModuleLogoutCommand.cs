using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.ModuleLogout
{
    public record ModuleLogoutCommand(string UserId, string SessionId, string ServiceName) : ICommand;
}
