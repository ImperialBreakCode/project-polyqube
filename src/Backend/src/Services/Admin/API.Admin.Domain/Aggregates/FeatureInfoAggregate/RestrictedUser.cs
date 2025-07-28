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
            RestrictedUserId = userId;
        }

        public string RestrictedUserId { get; private set; }

        public static RestrictedUser Create(string userId)
        {
            return new(userId);
        }
    }
}
