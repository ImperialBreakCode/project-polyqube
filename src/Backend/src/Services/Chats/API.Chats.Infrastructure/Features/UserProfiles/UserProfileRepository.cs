using API.Chats.Common.Features.UserProfiles.Exceptions;
using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using API.Chats.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Chats.Infrastructure.Features.UserProfiles
{
    internal class UserProfileRepository : SoftDeleteRepository<UserProfile>, IUserProfileRepository
    {
        private readonly ChatDbContext _context;

        public UserProfileRepository(ChatDbContext context) : base(context.UserProfile)
        {
            _context = context;
        }

        public async Task<ICollection<BlockedProfile>> GetBlockedProfilesByBlockedProfileId(string profileId)
        {
            return await _context.BlockedProfiles
                .AsNoTracking()
                .Include(x => x.BlockedBy)
                .Where(x => x.BlockedUserId == profileId)
                .ToListAsync();
        }

        public async Task<UserProfile?> GetProfileByUserId(string userId, bool includeDeleted = default)
        {
            if (includeDeleted)
            {
                return await DbSet.FirstOrDefaultAsync(x => x.UserId == userId);
            }

            return await DbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.DeletedAt == null);
        }

        public override void Insert(UserProfile entity)
        {
            if (DbSet.Any(x => x.UserId == entity.UserId))
            {
                throw new ProfileAlreadyExistsException();
            }

            base.Insert(entity);
        }
    }
}
