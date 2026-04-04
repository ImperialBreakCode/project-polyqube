using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Chats.Infrastructure.Features.UserProfiles
{
    internal class UserProfileConfig : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.ToTable("user_profile");

            builder
                .HasIndex(x => x.UserId)
                .IsUnique();

            builder
                .HasMany(up => up.BlockedProfiles)
                .WithOne(bp => bp.BlockedBy)
                .HasForeignKey(bp => bp.BlockedById)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany<BlockedProfile>()
                .WithOne(bp => bp.BlockedUser)
                .HasForeignKey(bp => bp.BlockedUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
