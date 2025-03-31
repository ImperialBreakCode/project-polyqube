using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Queries.GetSessionsByUserId
{
    public record GetSessionsByUserIdQuery(string UserId) : IQuery<ICollection<SessionViewModel>>;
}
