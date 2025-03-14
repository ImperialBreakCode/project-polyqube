using API.Shared.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace API.Shared.Web.Auth.Authorization
{
    internal class RoleRequirementHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == APIClaimNames.RoleClaim))
            {
                return Task.CompletedTask;
            }

            var rolesClaim = context.User.FindFirst(c => c.Type == APIClaimNames.RoleClaim)!.Value;
            var roleList = JsonConvert.DeserializeObject<ICollection<string>>(rolesClaim);

            if (roleList is null)
            {
                return Task.CompletedTask;
            }

            if (roleList.Contains(requirement.RequiredRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
