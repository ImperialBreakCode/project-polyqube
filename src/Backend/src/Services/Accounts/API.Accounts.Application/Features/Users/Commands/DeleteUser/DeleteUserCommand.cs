using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.DeleteUser
{
    public record DeleteUserCommand(string UserDeletionToken) : ICommand;
}
