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

        public IssuerResult IssueAccessToken(User user, string[] roles)
        {
            var offset = DateTimeOffset.UtcNow.AddMinutes(30);

            string token = CreateTokenBase(user, out string tokenId)
                .AddClaim(APIClaimNames.ExpirationClaim, offset.ToUnixTimeSeconds())
                .AddClaim(APIClaimNames.RoleClaim, roles)
                .Encode();

            return IssuerResult.Create(token, offset, tokenId);
        }

        public IssuerResult IssueRefreshToken(User user)
        {
            var offset = DateTimeOffset.UtcNow.AddHours(2);

            string token = CreateTokenBase(user, out string tokenId)
                .AddClaim(APIClaimNames.ExpirationClaim, offset.ToUnixTimeSeconds())
                .Encode();

            return IssuerResult.Create(token, offset, tokenId);
        }

        private JwtBuilder CreateTokenBase(User user, out string tokenId)
        {
            tokenId = Guid.NewGuid().ToString();

            return JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA512Algorithm())
                .WithSecret(_optionsMonitor.CurrentValue.SecretKey)
                .AddClaim(APIClaimNames.IssuerClaim, _optionsMonitor.CurrentValue.Issuer)
                .AddClaim(APIClaimNames.AudianceClaim, _optionsMonitor.CurrentValue.Audience)
                .AddClaim(APIClaimNames.TokenIdClaim, tokenId)
                .AddClaim(APIClaimNames.SubjectClaim, user.Id);

        }
    }
}
