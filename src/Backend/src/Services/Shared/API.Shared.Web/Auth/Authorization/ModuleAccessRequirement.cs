using Microsoft.AspNetCore.Authorization;

namespace API.Shared.Web.Auth.Authorization
{
    internal class ModuleAccessRequirement(params string[] moduleNames) : IAuthorizationRequirement
    {
        public string[] RequiredModules { get; set; } = moduleNames;
    }
}
