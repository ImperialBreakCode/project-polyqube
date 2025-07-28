using API.Shared.Domain.Base.Entity;

namespace API.Admin.Domain.Aggregates.FeatureInfoAggregate
{
    public class TestUser : BaseCreatedAtEntity
    {
        private TestUser()
        {
        }

        private TestUser(string userId)
        {
            TestUserId = userId;
        }

        public string TestUserId { get; private set; }

        public static TestUser Create(string userId)
        {
            return new(userId);
        }
    }
}
