using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.RequestUserDeletion
{
    public record RequestUserDeletionCommand(string UserId, string Password) : ICommand<UserEmailViewModel>;
}
