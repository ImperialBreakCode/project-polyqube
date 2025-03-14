using API.Accounts.Application.Features.Users.Queries.GetUserByUsername;

namespace API.Accounts.Application.Features.Users.Factories
{
    public interface IUserQueryFactory
    {
        GetUserByUsernameQuery CreateGetByUsernameQuery(string username);
    }
}
