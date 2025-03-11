using API.Accounts.Application.Features.Users.Options;
using API.Shared.Common.Constants;
using API.Shared.Common.Exceptions;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using Microsoft.Extensions.Options;

namespace API.Accounts.Application.Features.Users.AuthToken
{
    public class AuthTokenVerifier : IAuthTokenVerifier
    {
        private readonly IOptionsMonitor<AuthTokenOptions> _authTokenOptions;

        public AuthTokenVerifier(IOptionsMonitor<AuthTokenOptions> authTokenOptions)
        {
            _authTokenOptions = authTokenOptions;
        }

        public IDictionary<string, object> VerifyToken(string token)
        {
            var payload = GetPayload(token);

            if (!payload.ContainsKey(APIClaimNames.AudianceClaim)
                || payload[APIClaimNames.AudianceClaim].ToString() != _authTokenOptions.CurrentValue.Audience)
            {
                throw new UnauthorizedException("Invalid token audiance");
            }

            if (!payload.ContainsKey(APIClaimNames.IssuerClaim)
                || payload[APIClaimNames.IssuerClaim].ToString() != _authTokenOptions.CurrentValue.Issuer)
            {
                throw new UnauthorizedException("Invalid token issuer");
            }

            return payload;
        }

        private IDictionary<string, object> GetPayload(string token)
        {
            try
            {
                var payload = JwtBuilder.Create()
                        .WithAlgorithm(new HMACSHA512Algorithm())
                        .WithSecret(_authTokenOptions.CurrentValue.SecretKey)
                        .MustVerifySignature()
                        .Decode<IDictionary<string, object>>(token);

                return payload;
            }
            catch (TokenExpiredException)
            {
                throw new UnauthorizedException("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                throw new UnauthorizedException("Token has invalid signature");
            }
        }
    }
}
