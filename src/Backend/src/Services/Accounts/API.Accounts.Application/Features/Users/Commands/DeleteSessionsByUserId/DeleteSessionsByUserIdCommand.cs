using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.DeleteSessionsByUserId
{
    public record DeleteSessionsByUserIdCommand(string UserId) : ICommand;
}
