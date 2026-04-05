using API.Shared.Domain.Base;

namespace API.Chats.Domain.Aggregates
{
    public enum ChatFeatureMode
    {
        On,
        Off,
        Test
    }

    public class ChatFeature : AuditableAggregateRoot
    {
        private ChatFeature() { }

        private ChatFeature(string featureName, ChatFeatureMode featureMode)
        {
            FeatureName = featureName;
            Mode = featureMode;
        }

        public string FeatureName { get; private set; }
        public ChatFeatureMode Mode { get; set; }
        public bool UserRestrictionsEnabled { get; set; }

        public static ChatFeature Create(string featureName, ChatFeatureMode featureMode)
        {
            return new(featureName, featureMode);
        }
    }
}
