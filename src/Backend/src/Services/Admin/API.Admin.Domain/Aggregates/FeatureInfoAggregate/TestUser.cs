using API.Shared.Domain.Base.Entity;

namespace API.Admin.Domain.Aggregates.FeatureInfoAggregate
{
    public class TestUser : BaseCreatedAtEntity
    {
        private TestUser()
        {
        }

        private TestUser(string userId, string featureInfoId)
        {
            TestUserId = userId;
            FeatureInfoId = featureInfoId;
        }

        public string TestUserId { get; private set; }
        public string FeatureInfoId { get; private set; }

        public static TestUser Create(string userId, string featureInfoId)
        {
            return new(userId, featureInfoId);
        }
    }
}
