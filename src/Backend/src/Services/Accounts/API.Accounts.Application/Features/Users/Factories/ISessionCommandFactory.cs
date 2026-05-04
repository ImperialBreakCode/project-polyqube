using API.Accounts.Application.Features.Users.Commands.DeleteSessionsByUserId;
using API.Accounts.Application.Features.Users.Commands.ModuleLogout;
using API.Accounts.Application.Features.Users.Commands.ModuleLogin;
using API.Accounts.Application.Features.Users.Commands.RequestModuleAccess;
using API.Accounts.Application.Features.Users.Commands.RevokeSession;

namespace API.Accounts.Application.Features.Users.Factories
{
    public interface ISessionCommandFactory
    {
        DeleteSessionsByUserIdCommand CreateDeleteSessionsByUserIdCommand(string userId);
        RevokeSessionCommand CreateRevokeSessionCommand(string userId, string sessionId);
        ModuleLogoutCommand CreateModuleLogoutCommand(string userId, string sessionId, string serviceName);
        ModuleLoginCommand CreateModuleLoginCommand(string code);
        RequestModuleAccessCommand CreateRequestModuleAccessCommand(
            string userId, 
            string sessionId,
            string accessToken,
            string refreshToken,
            string moduleName);
    }
}
