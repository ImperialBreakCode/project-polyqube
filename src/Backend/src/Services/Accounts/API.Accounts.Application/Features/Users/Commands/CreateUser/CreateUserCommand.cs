using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.CreateUser
{
    public record CreateUserCommand(string Username, string Email, string Password) : ICommand<UserViewModel>;
}
