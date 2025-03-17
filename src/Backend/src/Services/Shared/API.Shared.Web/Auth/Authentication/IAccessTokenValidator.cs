using API.Shared.Web.Models;

namespace API.Shared.Web.Auth.Authentication
{
    internal interface IAccessTokenValidator
    {
        Task<AccessTokenValidationResult> Validate(string accessToken);
    }
}
