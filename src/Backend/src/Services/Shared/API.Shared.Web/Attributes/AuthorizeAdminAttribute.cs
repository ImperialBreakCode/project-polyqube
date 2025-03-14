using API.Shared.Common.Constants;
using Microsoft.AspNetCore.Authorization;

namespace API.Shared.Web.Attributes
{
    public class AuthorizeAdminAttribute : AuthorizeAttribute
    {
        public AuthorizeAdminAttribute()
            : base(policy: AuthorizationPolices.ADMIN_ROLE_POLICY)
        {
        }
    }
}
