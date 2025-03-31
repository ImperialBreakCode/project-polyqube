using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Queries.GetUserById
{
    public record GetUserByIdQuery(string Id) : IQuery<UserViewModel>;
}
