using API.Chats.Common.Features.UserProfiles.Exceptions;
using API.Shared.Domain.Base;

namespace API.Chats.Domain.Aggregates.UserProfilesAggregate
{
    public class UserProfile : AuditableSoftDeleteAggregateRoot
    {
        private readonly ICollection<BlockedProfile> _blockedProfiles;

        private UserProfile()
        {
        }

        private UserProfile(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; private set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public bool LockedOut { get; set; }
        public bool Disabled { get; set; }
        public bool Suspended { get; set; }

        public IReadOnlyCollection<BlockedProfile> BlockedProfiles =>
            _blockedProfiles
            .ToList();

        public void BlockProfile(string profileUserId)
        {
            bool recordExists = BlockedProfiles
                .Any(x => x.BlockedUserId == profileUserId);
            if (recordExists)
            {
                throw new UserAlreadyBlockedException();
            }

            _blockedProfiles.Add(BlockedProfile.Create(profileUserId, Id));
        }

        public static UserProfile Create(string userId)
        {
            return new UserProfile(userId);
        }
    }
}
