using API.Shared.Common.Constants;
using Microsoft.AspNetCore.Authorization;

namespace API.Shared.Web.Attributes
{
    public class AuthorizeAdminScopeAttribute : AuthorizeAttribute
    {
        public AuthorizeAdminScopeAttribute()
            : base(policy: AuthorizationPolices.ADMIN_SCOPE_POLICY)
        {
        }
    }
}
