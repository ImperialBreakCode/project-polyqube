using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Domain.Interfaces.Entity;

namespace API.Accounts.Domain.Aggregates
{
    public class UserRole : ICreatedAtAuditable
    {
        public string UserId { get; private set; }
        public User User { get; private set; }

        public string RoleId { get; private set; }
        public Role Role { get; private set; }

        public DateTime CreatedAt { get; private set; }

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

        public DateTime SetCreatedAtTimestamp()
        {
            if (CreatedAt == DateTime.MinValue)
            {
                CreatedAt = DateTime.UtcNow;
            }

            return CreatedAt;
        }
    }
}
