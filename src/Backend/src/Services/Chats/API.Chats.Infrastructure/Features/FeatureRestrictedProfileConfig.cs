using API.Chats.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Chats.Infrastructure.Features
{
    internal class FeatureRestrictedProfileConfig : IEntityTypeConfiguration<FeatureRestrictedProfile>
    {
        public void Configure(EntityTypeBuilder<FeatureRestrictedProfile> builder)
        {
            builder.ToTable("feature_restricted_user");

            builder.HasOne(fru => fru.RestrictedProfile)
                .WithMany()
                .HasForeignKey(fru => fru.RestrictedProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fru => fru.ChatFeature)
                .WithMany()
                .HasForeignKey(fru => fru.ChatFeatureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(ur => new { ur.RestrictedProfileId, ur.ChatFeatureId });
        }
    }
}
