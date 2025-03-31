using API.Accounts.Application.Features.Users.Queries.GetUserById;
using API.Accounts.Application.Features.Users.Queries.GetUserByUsername;

namespace API.Accounts.Application.Features.Users.Factories
{
    public interface IUserQueryFactory
    {
        GetUserByUsernameQuery CreateGetUserByUsernameQuery(string username);
        GetUserByIdQuery CreateGetUserByIdQuery(string id);
    }
}
