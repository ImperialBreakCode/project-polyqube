using API.Shared.Common.Constants;
using Microsoft.AspNetCore.Authorization;

namespace API.Shared.Web.Attributes
{
    public class AuthorizeModuleAccessAttribute : AuthorizeAttribute
    {
        public AuthorizeModuleAccessAttribute()
            : base(policy: AuthorizationPolices.MODULE_ACCESS_POLICY)
        {
            
        }
    }
}
