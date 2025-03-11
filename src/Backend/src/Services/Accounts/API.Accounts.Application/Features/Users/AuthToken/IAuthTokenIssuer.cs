using API.Accounts.Domain.Aggregates.UserAggregate;

namespace API.Accounts.Application.Features.Users.AuthToken
{
    internal interface IAuthTokenIssuer
    {
        string IssueToken(User user, string[] roles);
    }
}
