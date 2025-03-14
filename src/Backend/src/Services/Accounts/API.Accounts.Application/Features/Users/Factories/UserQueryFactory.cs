using API.Accounts.Application.Features.Users.Queries.GetUserByUsername;

namespace API.Accounts.Application.Features.Users.Factories
{
    internal class UserQueryFactory : IUserQueryFactory
    {
        public GetUserByUsernameQuery CreateGetByUsernameQuery(string username)
        {
            return new GetUserByUsernameQuery(username);
        }
    }
}
