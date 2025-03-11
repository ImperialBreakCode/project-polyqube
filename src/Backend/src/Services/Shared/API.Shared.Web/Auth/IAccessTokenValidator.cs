using API.Shared.Web.Models;

namespace API.Shared.Web.Auth
{
    internal interface IAccessTokenValidator
    {
        Task<AccessTokenValidationResult> Validate(string accessToken);
    }
}
