using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Domain.Base;

namespace API.Accounts.Domain.Aggregates
{
    public class UserRole : CreatedAtAuditable
    {
        public string UserId { get; private set; }
        public User User { get; private set; }

        public string RoleId { get; private set; }
        public Role Role { get; private set; }

        private UserRole() { }

        private UserRole(string userId, string roleId) 
        {

            UserId = userId;
            RoleId = roleId;
        }

        public static UserRole Create(string userId, string roleId)
        {
            return new UserRole(userId, roleId);
        }
    }
}
