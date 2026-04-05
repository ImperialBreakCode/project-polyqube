using API.Chats.Common.Features.UserProfiles.Exceptions;
using API.Shared.Domain.Base;

namespace API.Chats.Domain.Aggregates.UserProfilesAggregate
{
    public class BlockedProfile : CreatedAtAuditable
    {
        private BlockedProfile()
        {
        }

        private BlockedProfile(string blockedUserId, string blockedById)
        {
            BlockedById = blockedUserId;
            BlockedUserId = blockedById;
        }

        public string BlockedUserId { get; private set; }
        public UserProfile BlockedUser { get; private set; }

        public string BlockedById { get; private set; }
        public UserProfile BlockedBy { get; private set; }

        public static BlockedProfile Create(string blockedUserId, string blockedById)
        {
            if (blockedUserId == blockedById)
            {

                throw new CannotSelfBlockException();
            }

            return new BlockedProfile(blockedUserId, blockedById);
        }
    }
}
