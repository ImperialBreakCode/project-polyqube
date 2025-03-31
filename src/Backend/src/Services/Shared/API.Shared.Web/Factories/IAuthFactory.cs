using API.Shared.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Shared.Web.Factories
{
    internal interface IAuthFactory
    {
        ValidateAccessTokenRequestDTO CreateValidateAccessTokenRequest(string accessToken);
        AccessTokenValidationResult ValidateAccessTokenValidationResult(AccessTokenPayloadResponseDTO? payloadResponseDTO, ProblemDetails? problemDetails);
    }
}
