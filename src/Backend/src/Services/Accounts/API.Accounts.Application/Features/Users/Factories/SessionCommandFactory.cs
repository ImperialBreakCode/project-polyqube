using API.Accounts.Application.Features.Users.Commands.DeleteSessionsByUserId;

namespace API.Accounts.Application.Features.Users.Factories
{
    internal class SessionCommandFactory : ISessionCommandFactory
    {
        public DeleteSessionsByUserIdCommand CreateDeleteSessionsByUserIdCommand(string userId)
        {
            return new DeleteSessionsByUserIdCommand(userId);
        }
    }
}
