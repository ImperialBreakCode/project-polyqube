using API.Accounts.Application.Features.Users.Options;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Common.Constants;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Options;

namespace API.Accounts.Application.Features.Users.AuthToken.Issuer
{
    internal class AuthTokenIssuer : IAuthTokenIssuer
    {
        private readonly IOptionsMonitor<AuthTokenOptions> _optionsMonitor;

        public AuthTokenIssuer(IOptionsMonitor<AuthTokenOptions> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor;
        }

        public string IssueAccessToken(User user, string[] roles)
        {
            string token = CreateTokenBase(user)
                .AddClaim(APIClaimNames.ExpirationClaim, DateTimeOffset.UtcNow.AddMinutes(30).ToUnixTimeSeconds())
                .AddClaim(APIClaimNames.RoleClaim, roles)
                .Encode();

            return token;
        }

        public string IssueRefreshToken(User user)
        {
            string token = CreateTokenBase(user)
                .AddClaim(APIClaimNames.ExpirationClaim, DateTimeOffset.UtcNow.AddHours(2).ToUnixTimeSeconds())
                .Encode();

            return token;
        }

        private JwtBuilder CreateTokenBase(User user)
        {
            return JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA512Algorithm())
                .WithSecret(_optionsMonitor.CurrentValue.SecretKey)
                .AddClaim(APIClaimNames.IssuerClaim, _optionsMonitor.CurrentValue.Issuer)
                .AddClaim(APIClaimNames.AudianceClaim, _optionsMonitor.CurrentValue.Audience)
                //.AddClaim("sub", user.Id)
                .AddClaim(APIClaimNames.UsernameClaim, user.Username);

        }
    }
}
