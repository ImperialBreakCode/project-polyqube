using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.ModuleLogin
{
    public record ModuleLoginCommand(string Code) : ICommand<AuthTokensViewModel>;
}
