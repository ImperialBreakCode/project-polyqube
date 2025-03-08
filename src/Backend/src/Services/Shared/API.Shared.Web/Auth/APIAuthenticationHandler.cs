using API.Shared.Application.Auth.AuthTokenVerifier;
using API.Shared.Application.Auth.Exceptions;
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

namespace API.Shared.Web.Auth
{
    internal class APIAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IAuthTokenVerifier _authTokenVerifier;
        private string _failureMessage;

        public APIAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            IAuthTokenVerifier authTokenVerifier)
            : base(options, logger, encoder)
        {
            _authTokenVerifier = authTokenVerifier;
            _failureMessage = string.Empty;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(token))
            {
                _failureMessage = "Invalid Authorization Header";
                return Task.FromResult(AuthenticateResult.Fail(_failureMessage));
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
                _failureMessage = ex.Message;
                return Task.FromResult(AuthenticateResult.Fail(ex.Message));
            }
            catch (Exception)
            {
                _failureMessage = "Unknown error occured";
                return Task.FromResult(AuthenticateResult.Fail(_failureMessage));
            }
        }

        protected override async Task HandleChallengeAsync(AuthenticationProperties properties)
        {

            await base.HandleChallengeAsync(properties);

            var statusCode = HttpStatusCode.Unauthorized;

            Response.StatusCode = (int)statusCode;
            Response.ContentType = "application/json";

            var problemDetails = new ProblemDetails()
            {
                Title = Enum.GetName(statusCode)!,
                Type = "AuthError",
                Detail = _failureMessage,
                Status = (int)statusCode
            };

            await Response.WriteAsync(JsonConvert.SerializeObject(problemDetails));
        }

        private Claim CreateClaim(string claimName, IDictionary<string, object> claimValues)
        {
            return new Claim(claimName, JsonConvert.SerializeObject(claimValues[claimName]));
        }
    }
}
