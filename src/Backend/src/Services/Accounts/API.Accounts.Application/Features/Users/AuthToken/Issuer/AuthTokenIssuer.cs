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
        private string _tokenId;

        public AuthTokenIssuer(IOptionsMonitor<AuthTokenOptions> optionsMonitor)
        {
            _optionsMonitor = optionsMonitor;
            RefreshId();
        }

        public IssuerResult IssueAccessToken(User user, string[] roles)
        {
            var offset = DateTimeOffset.UtcNow.AddDays(10);

            string token = CreateTokenBase(user)
                .AddClaim(APIClaimNames.ExpirationClaim, offset.ToUnixTimeSeconds())
                .AddClaim(APIClaimNames.RoleClaim, roles)
                .Encode();

            return IssuerResult.Create(token, offset, _tokenId);
        }

        public IssuerResult IssueRefreshToken(User user)
        {
            var offset = DateTimeOffset.UtcNow.AddDays(20);

            string token = CreateTokenBase(user)
                .AddClaim(APIClaimNames.ExpirationClaim, offset.ToUnixTimeSeconds())
                .Encode();

            return IssuerResult.Create(token, offset, _tokenId);
        }

        public void RefreshId()
        {
            _tokenId = Guid.NewGuid().ToString();
        }

        private JwtBuilder CreateTokenBase(User user)
        {
            return JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA512Algorithm())
                .WithSecret(_optionsMonitor.CurrentValue.SecretKey)
                .AddClaim(APIClaimNames.IssuerClaim, _optionsMonitor.CurrentValue.Issuer)
                .AddClaim(APIClaimNames.AudianceClaim, _optionsMonitor.CurrentValue.Audience)
                .AddClaim(APIClaimNames.TokenIdClaim, _tokenId)
                .AddClaim(APIClaimNames.SubjectClaim, user.Id);

        }
    }
}
