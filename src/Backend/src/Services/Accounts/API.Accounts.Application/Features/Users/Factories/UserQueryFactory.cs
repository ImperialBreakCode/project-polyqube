using API.Accounts.Application.Features.Users.Queries.GetUserById;
using API.Accounts.Application.Features.Users.Queries.GetUserByUsername;

namespace API.Accounts.Application.Features.Users.Factories
{
    internal class UserQueryFactory : IUserQueryFactory
    {
        public GetUserByIdQuery CreateGetUserByIdQuery(string id)
        {
            return new GetUserByIdQuery(id);
        }

        public GetUserByUsernameQuery CreateGetUserByUsernameQuery(string username)
        {
            return new GetUserByUsernameQuery(username);
        }
    }
}
