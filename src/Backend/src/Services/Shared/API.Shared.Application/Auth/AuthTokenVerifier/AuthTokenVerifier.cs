using API.Accounts.Application.Features.Users.Options;
using API.Shared.Application.Auth.Exceptions;
using API.Shared.Common.Constants;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using Microsoft.Extensions.Options;

namespace API.Shared.Application.Auth.AuthTokenVerifier
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
                throw new InvalidAuthTokenException("Invalid audiance");
            }

            if (!payload.ContainsKey(APIClaimNames.IssuerClaim)
                || payload[APIClaimNames.IssuerClaim].ToString() != _authTokenOptions.CurrentValue.Issuer)
            {
                throw new InvalidAuthTokenException("Invalid issuer");
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
            catch (TokenNotYetValidException)
            {
                throw new InvalidAuthTokenException("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                throw new InvalidAuthTokenException("Token has invalid signature");
            }
        }
    }
}
