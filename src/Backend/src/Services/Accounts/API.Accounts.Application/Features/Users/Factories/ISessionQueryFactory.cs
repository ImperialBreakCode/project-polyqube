using API.Accounts.Application.Features.Users.Queries.GetSessionsByUserId;

namespace API.Accounts.Application.Features.Users.Factories
{
    public interface ISessionQueryFactory
    {
        GetSessionsByUserIdQuery CreateGetSessionsByUserIdQuery(string userId);
    }
}
