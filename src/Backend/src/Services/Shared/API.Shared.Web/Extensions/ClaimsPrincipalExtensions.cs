using API.Shared.Common.Constants;
using Newtonsoft.Json;
using System.Security.Claims;

namespace API.Shared.Web.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            var subjectClaim = user.FindFirst(APIClaimNames.SubjectClaim);

            if (subjectClaim is null)
            {
                return string.Empty;
            }

            return JsonConvert.DeserializeObject<string>(subjectClaim.Value) ?? string.Empty;
        }
    }
}
