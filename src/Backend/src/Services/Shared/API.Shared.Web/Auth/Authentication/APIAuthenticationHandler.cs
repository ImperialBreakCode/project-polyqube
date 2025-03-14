using API.Shared.Common.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace API.Shared.Web.Auth.Authentication
{
    internal class APIAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private IAccessTokenValidator _accessTokenValidator;

        private ProblemDetails? _problemDetails;

        public APIAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            IAccessTokenValidator accessTokenValidator)
            : base(options, logger, encoder)
        {
            _accessTokenValidator = accessTokenValidator;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(token))
            {
                _problemDetails = new ProblemDetails()
                {
                    Title = Enum.GetName(HttpStatusCode.Unauthorized),
                    Type = "UnauthorizedException",
                    Status = (int)HttpStatusCode.Unauthorized,
                    Detail = "Invalid Authorization Header"
                };

                return AuthenticateResult.Fail(_problemDetails.Detail);
            }

            var result = await _accessTokenValidator.Validate(token);

            if (result.ProblemDetails is not null)
            {
                _problemDetails = result.ProblemDetails;
                return AuthenticateResult.Fail(_problemDetails.Detail!);
            }

            var claimsDict = result.Payload!.Payload;

            var claims = new[] {
                CreateClaim(APIClaimNames.UsernameClaim, claimsDict),
                CreateClaim(APIClaimNames.RoleClaim, claimsDict),
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {
            Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            Response.ContentType = "application/json";

            await Response.WriteAsync(JsonConvert.SerializeObject(_problemDetails));
        }

        private Claim CreateClaim(string claimName, IDictionary<string, object> claimValues)
        {
            return new Claim(claimName, JsonConvert.SerializeObject(claimValues[claimName]));
        }
    }
}
