using API.Accounts.Application.Features.Users.Commands.DeleteSessionsByUserId;
using API.Accounts.Application.Features.Users.Commands.RevokeSession;

namespace API.Accounts.Application.Features.Users.Factories
{
    internal class SessionCommandFactory : ISessionCommandFactory
    {
        public DeleteSessionsByUserIdCommand CreateDeleteSessionsByUserIdCommand(string userId)
        {
            return new DeleteSessionsByUserIdCommand(userId);
        }

        public RevokeSessionCommand CreateRevokeSessionCommand(string userId, string sessionId)
        {
            return new RevokeSessionCommand(userId, sessionId);
        }
    }
}
