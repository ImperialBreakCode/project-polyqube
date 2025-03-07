using API.Shared.Application.Auth.AuthTokenVerifier;
using API.Shared.Application.Auth.Exceptions;
using API.Shared.Common.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace API.Shared.Web.Auth
{
    internal class APIAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IAuthTokenVerifier _authTokenVerifier;

        public APIAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            IAuthTokenVerifier authTokenVerifier)
            : base(options, logger, encoder)
        {
            _authTokenVerifier = authTokenVerifier;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(token))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid Authorization Header"));
            }

            try
            {
                var claimsDict = _authTokenVerifier.VerifyToken(token);

                var claims = new[] {
                    CreateClaim(APIClaimNames.UsernameClaim, claimsDict),
                    CreateClaim(APIClaimNames.RoleClaim, claimsDict),
                };

                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return Task.FromResult(AuthenticateResult.Success(ticket));

            }
            catch (InvalidAuthTokenException ex)
            {
                return Task.FromResult(AuthenticateResult.Fail(ex.Message));
            }
            catch (Exception)
            {

                return Task.FromResult(AuthenticateResult.Fail("Unknown error occured"));
            }
        }

        private Claim CreateClaim(string claimName, IDictionary<string, string> claimValues)
        {
            return new Claim(claimName, claimValues[claimName]);
        }
    }
}
