using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Domain.Base.Entity;

namespace API.Accounts.Domain.Aggregates
{
    public class UserDeletionToken : BaseCreatedAtEntity
    {
        private UserDeletionToken()
        {
        }

        private UserDeletionToken(DateTime expiry, string token, User user)
        {
            Expiry = expiry;
            Token = token;
            User = user;
        }

        public DateTime Expiry { get; private set; }
        public string Token { get; private set; }
        public User User { get; private set; }

        public static UserDeletionToken Create(User user)
        {
            return new UserDeletionToken(DateTime.UtcNow.AddHours(2), Guid.NewGuid().ToString(), user);
        }
    }
}
