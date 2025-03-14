using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Queries.GetUserByUsername
{
    public record GetUserByUsernameQuery(string Username) : IQuery<UserViewModel>;
}
