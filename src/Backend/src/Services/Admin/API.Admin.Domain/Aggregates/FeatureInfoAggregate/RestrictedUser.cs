using API.Shared.Domain.Base.Entity;

namespace API.Admin.Domain.Aggregates.FeatureInfoAggregate
{
    public class RestrictedUser : BaseCreatedAtEntity
    {
        private RestrictedUser()
        {
        }

        private RestrictedUser(string userId, string featureInfoId)
        {
            RestrictedUserId = userId;
            FeatureInfoId = featureInfoId;
        }

        public string RestrictedUserId { get; private set; }
        public string FeatureInfoId { get; private set; }

        public static RestrictedUser Create(string userId, string featureInfoId)
        {
            return new(userId, featureInfoId);
        }
    }
}
