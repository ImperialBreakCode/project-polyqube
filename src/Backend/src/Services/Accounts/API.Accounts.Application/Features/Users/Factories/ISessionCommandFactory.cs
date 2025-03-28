using API.Accounts.Application.Features.Users.Commands.DeleteSessionsByUserId;

namespace API.Accounts.Application.Features.Users.Factories
{
    public interface ISessionCommandFactory
    {
        DeleteSessionsByUserIdCommand CreateDeleteSessionsByUserIdCommand(string userId);
    }
}
