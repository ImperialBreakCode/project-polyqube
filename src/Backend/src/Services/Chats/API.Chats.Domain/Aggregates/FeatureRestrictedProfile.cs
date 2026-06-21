using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using API.Shared.Domain.Base;

namespace API.Chats.Domain.Aggregates
{
    public class FeatureRestrictedProfile : CreatedAtAuditable
    {
        private FeatureRestrictedProfile()
        {
        }

        private FeatureRestrictedProfile(string chatFeatureId, string restrictedProfileId)
        {
            ChatFeatureId = chatFeatureId;
            RestrictedProfileId = restrictedProfileId;
        }

        public string ChatFeatureId { get; private set; }
        public ChatFeature ChatFeature { get; private set; }

        public string RestrictedProfileId { get; private set; }
        public UserProfile RestrictedProfile { get; private set; }

        public static FeatureRestrictedProfile Create(string chatFeatureId, string restrictedProfileId)
        {
            return new FeatureRestrictedProfile(chatFeatureId, restrictedProfileId);
        }
    }
}
