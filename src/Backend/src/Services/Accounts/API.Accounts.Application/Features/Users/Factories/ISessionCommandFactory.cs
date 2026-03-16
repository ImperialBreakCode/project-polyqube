using API.Accounts.Application.Features.Users.Commands.DeleteSessionsByUserId;
using API.Accounts.Application.Features.Users.Commands.RevokeSession;

namespace API.Accounts.Application.Features.Users.Factories
{
    public interface ISessionCommandFactory
    {
        DeleteSessionsByUserIdCommand CreateDeleteSessionsByUserIdCommand(string userId);
        RevokeSessionCommand CreateRevokeSessionCommand(string userId, string sessionId);
    }
}
