using API.Shared.Common.Constants;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Shared.Web.Extensions
{
    public static class ControllerExtensions
    {
        public static string GetUserId(this ControllerBase controller)
        {
            var subjectClaim = controller.HttpContext.User.FindFirst(APIClaimNames.SubjectClaim);

            var id = string.Empty;

            if (subjectClaim is not null)
            {
                id = JsonConvert.DeserializeObject<string>(subjectClaim.Value) ?? string.Empty;
            }

            return id;
        }
    }
}
