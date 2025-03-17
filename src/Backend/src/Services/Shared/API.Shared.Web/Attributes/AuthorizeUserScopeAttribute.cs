using API.Shared.Common.Constants;
using Microsoft.AspNetCore.Authorization;

namespace API.Shared.Web.Attributes
{
    public class AuthorizeUserScopeAttribute : AuthorizeAttribute
    {
        public AuthorizeUserScopeAttribute() 
            : base(policy: AuthorizationPolices.USER_SCOPE_POLICY)
        { 
        }
    }
}
