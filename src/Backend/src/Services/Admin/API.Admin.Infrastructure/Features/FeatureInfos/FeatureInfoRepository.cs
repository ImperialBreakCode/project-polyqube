using API.Admin.Common.Features.FeatureInfo.Exceptions;
using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using API.Admin.Domain.Repositories;
using API.Shared.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Admin.Infrastructure.Features.FeatureInfos
{
    internal class FeatureInfoRepository : CRURepository<FeatureInfo>, IFeatureInfoRepository
    {
        private readonly AdminDbContext _dbContext;

        public FeatureInfoRepository(AdminDbContext dbContext) : base(dbContext.FeatureInfos)
        {
            _dbContext = dbContext;
        }

        public async Task<FeatureInfo?> GetByFeatureNameAsync(string featureName)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.FeatureName == featureName);
        }
        public async Task AddRestrictedUserAsync(RestrictedUser restrictedUser)
        {
            if (await CheckIfUserIsRestrictedAsync(restrictedUser.FeatureInfoId, restrictedUser.RestrictedUserId))
            {
                throw new RestrictedUserAlreadyExists();
            }

            await _dbContext.RestrictedUsers.AddAsync(restrictedUser);
        }

        public async Task AddTestUserAsync(TestUser testUser)
        {
            if (await CheckIfUserIsTestUserAsync(testUser.FeatureInfoId, testUser.TestUserId))
            {
                throw new TestUserAlreadyExists();
            }

            await _dbContext.TestUsers.AddAsync(testUser);
        }

        public async Task<bool> CheckIfUserIsRestrictedAsync(string featureId, string userId)
        {
            return await _dbContext.RestrictedUsers
                .AnyAsync(x => x.FeatureInfoId == featureId && x.RestrictedUserId == userId);
        }

        public async Task<bool> CheckIfUserIsTestUserAsync(string featureId, string userId)
        {
            return await _dbContext.TestUsers
                .AnyAsync(x => x.FeatureInfoId == featureId && x.TestUserId == userId);
        }

        public async Task<ICollection<RestrictedUser>> GetRestrictedUsersAsync(string featureId, int startPosition, int count = 100)
        {
            return await _dbContext.RestrictedUsers
                .Where(x => x.FeatureInfoId == featureId)
                .AsNoTracking()
                .Skip(startPosition)
                .Take(count)
                .ToListAsync();
        }

        public async Task<ICollection<TestUser>> GetTestUsersAsync(string featureId, int startPosition, int count = 100)
        {
            return await _dbContext.TestUsers
                .Where(x => x.FeatureInfoId == featureId)
                .AsNoTracking()
                .Skip(startPosition)
                .Take(count)
                .ToListAsync();
        }

        public void RemoveRestrictedUser(RestrictedUser restrictedUser)
        {
            _dbContext.RestrictedUsers.Remove(restrictedUser);
        }

        public void RemoveTestUser(TestUser testUser)
        {
            _dbContext.TestUsers.Remove(testUser);
        }
    }
}
