using API.Shared.Domain.Base.Entity;

namespace API.Admin.Domain.Aggregates.FeatureInfoAggregate
{
    public class RestrictedUser : BaseCreatedAtEntity
    {
        private RestrictedUser()
        {
        }

        private RestrictedUser(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; private set; }

        public static RestrictedUser Create(string userId)
        {
            return new(userId);
        }
    }
}
