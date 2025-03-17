using Microsoft.AspNetCore.Authorization;

namespace API.Shared.Web.Auth.Authorization
{
    internal class RoleRequirement(params string[] roles) : IAuthorizationRequirement
    {
        public string[] RequiredRoles { get; init; } = roles;
    }
}
