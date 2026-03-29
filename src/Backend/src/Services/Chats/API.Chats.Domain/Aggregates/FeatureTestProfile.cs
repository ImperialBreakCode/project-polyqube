using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using API.Shared.Domain.Base;

namespace API.Chats.Domain.Aggregates
{
    public class FeatureTestProfile : CreatedAtAuditable
    {
        private FeatureTestProfile()
        {
        }

        private FeatureTestProfile(string chatFeatureId, string testProfileId)
        {
            ChatFeatureId = chatFeatureId;
            TestProfileId = testProfileId;
        }

        public string ChatFeatureId { get; private set; }
        public ChatFeature ChatFeature { get; private set; }

        public string TestProfileId { get; private set; }
        public UserProfile TestProfile { get; private set; }

        public static FeatureTestProfile Create(string chatFeatureId, string testProfileId)
        {
            return new FeatureTestProfile(chatFeatureId, testProfileId);
        }
    }
}
