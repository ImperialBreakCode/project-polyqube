using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Chats.Infrastructure.Features.UserProfiles
{
    internal class BlockedProfileConfig : IEntityTypeConfiguration<BlockedProfile>
    {
        public void Configure(EntityTypeBuilder<BlockedProfile> builder)
        {
            builder.ToTable("blocked_profile");

            builder.HasKey(x => new { x.BlockedById, x.BlockedUserId});
        }
    }
}
