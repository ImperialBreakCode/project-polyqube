using Microsoft.AspNetCore.Authorization;

namespace API.Shared.Web.Auth.Authorization
{
    internal class RoleRequirement(string requiredRole) : IAuthorizationRequirement
    {
        public string RequiredRole { get; init; } = requiredRole;
    }
}
