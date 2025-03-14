using API.Shared.Common.Constants;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Shared.Web.Extensions
{
    public static class ControllerExtensions
    {
        public static string GetUsername(this ControllerBase controller)
        {
            var usernameClaim = controller.HttpContext.User.FindFirst(APIClaimNames.UsernameClaim);

            var username = string.Empty;

            if (usernameClaim is not null)
            {
                username = JsonConvert.DeserializeObject<string>(usernameClaim.Value) ?? string.Empty;
            }

            return username;
        }
    }
}
