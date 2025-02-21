using API.Shared.Domain.Base.Entity;
using API.Shared.Domain.Interfaces.Entity;

namespace API.Accounts.Domain.Aggregates.UserAggregate
{
    public class UserEmail : BaseCreatedAtEntity, IAuditable
    {
        private UserEmail() { }

        private UserEmail(string email) 
        {
            Email = email;
            IsPrimary = false;
            IsVerified = false;
        }

        public string Email { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsVerified { get; set; }

        public DateTime UpdatedAt { get; set; }

        public UserEmail Clone()
        {
            return new UserEmail()
            {
                Email = Email,
                IsPrimary = IsPrimary,
                UpdatedAt = UpdatedAt,
                CreatedAt = CreatedAt,
                IsVerified = IsVerified,
                Id = Id
            };
        }

        internal static UserEmail Create(string email)
        {
            return new UserEmail(email);
        }
    }
}
