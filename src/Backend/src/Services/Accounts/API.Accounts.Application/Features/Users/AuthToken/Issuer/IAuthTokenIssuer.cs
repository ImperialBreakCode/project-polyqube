using API.Accounts.Domain.Aggregates.UserAggregate;

namespace API.Accounts.Application.Features.Users.AuthToken.Issuer
{
    internal interface IAuthTokenIssuer
    {
        string IssueAccessToken(User user, string[] roles);
        string IssueRefreshToken(User user);
    }
}
