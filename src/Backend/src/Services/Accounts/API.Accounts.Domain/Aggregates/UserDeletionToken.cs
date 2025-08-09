using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Domain.Base.Entity;

namespace API.Accounts.Domain.Aggregates
{
    public class UserDeletionToken : BaseCreatedAtEntity
    {
        public DateTime Expiry { get; set; }
        public string Token { get; set; }
        public User User { get; set; }
    }
}
