using API.Shared.Common.Constants;
using Microsoft.AspNetCore.Authorization;

namespace API.Shared.Web.Attributes
{
    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        public AuthorizeUserAttribute() 
            : base(policy: AuthorizationPolices.USER_ROLE_POLICY)
        { 
        }
    }
}
