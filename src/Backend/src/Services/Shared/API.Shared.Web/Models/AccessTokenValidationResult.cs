using Microsoft.AspNetCore.Mvc;

namespace API.Shared.Web.Models;

internal record AccessTokenValidationResult(AccessTokenPayloadResponseDTO? Payload, ProblemDetails? ProblemDetails);
