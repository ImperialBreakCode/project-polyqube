using API.Shared.Domain.Base;

namespace API.Admin.Domain.Aggregates.FeatureInfoAggregate
{
    public enum FeatureMode
    {
        On,
        Off,
        Test
    }

    public class FeatureInfo : AuditableAggregateRoot
    {
        private FeatureInfo() { }

        private FeatureInfo(string featureName, FeatureMode featureMode)
        {
            FeatureName = featureName;
            Mode = featureMode;
            RestrictedUsers = [];
            TestUsers = [];
        }

        public string FeatureName { get; private set; }
        public FeatureMode Mode { get; set; }
        public bool UserRestrictionsEnabled { get; set; }
        public ICollection<RestrictedUser> RestrictedUsers { get; private set; }
        public ICollection<TestUser> TestUsers { get; private set; }

        public static FeatureInfo Create(string featureName, FeatureMode featureMode)
        {
            return new(featureName, featureMode);
        }
    }
}
