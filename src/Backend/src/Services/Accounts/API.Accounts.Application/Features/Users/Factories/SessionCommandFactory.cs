using API.Accounts.Application.Features.Users.Commands.DeleteSessionsByUserId;
using API.Accounts.Application.Features.Users.Commands.RequestModuleAccess;
using API.Accounts.Application.Features.Users.Commands.RevokeSession;

namespace API.Accounts.Application.Features.Users.Factories
{
    internal class SessionCommandFactory : ISessionCommandFactory
    {
        public DeleteSessionsByUserIdCommand CreateDeleteSessionsByUserIdCommand(string userId)
        {
            return new DeleteSessionsByUserIdCommand(userId);
        }

        public RequestModuleAccessCommand CreateRequestModuleAccessCommand(string userId, string sessionId, string accessToken, string refreshToken, string moduleName)
        {
            return new RequestModuleAccessCommand(refreshToken, accessToken, userId, sessionId, moduleName);
        }

        public RevokeSessionCommand CreateRevokeSessionCommand(string userId, string sessionId)
        {
            return new RevokeSessionCommand(userId, sessionId);
        }
    }
}
