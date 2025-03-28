using API.Accounts.Application.Features.Users.Queries.GetSessionsByUserId;

namespace API.Accounts.Application.Features.Users.Factories
{
    internal class SessionQueryFactory : ISessionQueryFactory
    {
        public GetSessionsByUserIdQuery CreateGetSessionsByUserIdQuery(string userId)
        {
            return new GetSessionsByUserIdQuery(userId);
        }
    }
}
