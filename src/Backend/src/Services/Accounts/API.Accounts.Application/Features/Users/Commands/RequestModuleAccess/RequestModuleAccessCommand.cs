using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.RequestModuleAccess
{
    public record RequestModuleAccessCommand(
        string RefreshToken, 
        string AccessToken, 
        string UserId, 
        string SessionId, 
        string ModuleName) : ICommand<ModuleAuthDataViewModel>;
}
