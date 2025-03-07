using API.Accounts.Domain.Aggregates.UserAggregate;

namespace API.Accounts.Application.Features.Users.AuthTokenIssuer
{
    internal interface IAuthTokenIssuer
    {
        string IssueToken(User user, string role);
    }
}
