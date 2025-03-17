using API.Shared.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Shared.Web.Factories
{
    internal class AuthFactory : IAuthFactory
    {
        public ValidateAccessTokenRequestDTO CreateValidateAccessTokenRequest(string accessToken)
        {
            return new ValidateAccessTokenRequestDTO(accessToken);
        }

        public AccessTokenValidationResult ValidateAccessTokenValidationResult(AccessTokenPayloadResponseDTO? payloadResponseDTO, ProblemDetails? problemDetails)
        {
            return new AccessTokenValidationResult(payloadResponseDTO, problemDetails);
        }
    }
}
