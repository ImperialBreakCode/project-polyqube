using API.Accounts.Application.Features.Users.Options;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Common.Constants;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Options;

namespace API.Accounts.Application.Features.Users.AuthTokenIssuer
{
    internal class AuthTokenIssuer : IAuthTokenIssuer
    {
        private readonly IOptionsMonitor<AuthTokenOptions> _optionsMonitor;

        public AuthTokenIssuer(IOptionsMonitor<AuthTokenOptions> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor;
        }

        public string IssueToken(User user, string role)
        {
            string token = JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA512Algorithm())
                      .WithSecret(_optionsMonitor.CurrentValue.SecretKey)
                      .AddClaim(APIClaimNames.ExpirationClaim, DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                      .AddClaim(APIClaimNames.IssuerClaim, _optionsMonitor.CurrentValue.Issuer)
                      .AddClaim(APIClaimNames.AudianceClaim, _optionsMonitor.CurrentValue.Audience)
                      //.AddClaim("sub", user.Id)
                      .AddClaim(APIClaimNames.UsernameClaim, user.Username)
                      .AddClaim(APIClaimNames.RoleClaim, role)
                      .Encode();

            return token;
        }
    }
}
