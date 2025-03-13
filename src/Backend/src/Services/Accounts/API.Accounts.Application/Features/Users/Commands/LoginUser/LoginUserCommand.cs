using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.LoginUser;

public record LoginUserCommand(string Username, string Password) : ICommand<AuthTokensViewModel>;
