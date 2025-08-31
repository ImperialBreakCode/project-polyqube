using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Domain.Base.Entity;

namespace API.Accounts.Domain.Aggregates
{
    public class EmailVerificationToken : BaseCreatedAtEntity
    {
        private EmailVerificationToken() { }

        private EmailVerificationToken(DateTime expiry, string token, string email, User user, string userId)
        {
            Expiry = expiry;
            Token = token;
            Email = email;
            User = user;
            UserId = userId;
        }

        public DateTime Expiry { get; private set; }
        public string Token { get; private set; }
        public string Email { get; set; }

        public string UserId { get; private set; }
        public User User { get; private set; }

        public static EmailVerificationToken Create(User user, string email)
        {
            return new EmailVerificationToken(DateTime.UtcNow.AddMinutes(10), Guid.NewGuid().ToString(), email, user, user.Id);
        }
    }
}
