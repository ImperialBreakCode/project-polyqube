using API.Chats.Common.Features.UserProfiles.Exceptions;
using API.Shared.Domain.Interfaces.Entity;

namespace API.Chats.Domain.Aggregates.UserProfilesAggregate
{
    public class BlockedProfile : ICreatedAtAuditable
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

        public DateTime CreatedAt { get; private set; }

        public DateTime SetCreatedAtTimestamp()
        {
            if (CreatedAt == DateTime.MinValue)
            {
                CreatedAt = DateTime.UtcNow;
            }

            return CreatedAt;
        }

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
