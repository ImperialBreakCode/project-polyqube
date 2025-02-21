using API.Shared.Domain.Base.Entity;

namespace API.Accounts.Domain.Aggregates
{
    public class Role : BaseCreatedAtEntity
    {
        private Role(string roleName)
        {
            RoleName = roleName;
        }
 

        public string RoleName { get; set; }

        public static Role Create(string roleName)
        {
            return new Role(roleName);
        }
    }
}
