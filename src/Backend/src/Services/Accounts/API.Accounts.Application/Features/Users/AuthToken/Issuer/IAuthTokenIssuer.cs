using API.Accounts.Domain.Aggregates.UserAggregate;

namespace API.Accounts.Application.Features.Users.AuthToken.Issuer
{
    internal interface IAuthTokenIssuer
    {
        IssuerResult IssueAccessToken(User user, string[] roles);
        IssuerResult IssueRefreshToken(User user);
        void RefreshId();
    }
}
