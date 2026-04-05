using API.Chats.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Chats.Infrastructure.Features
{
    internal class FeatureTestProfileConfig : IEntityTypeConfiguration<FeatureTestProfile>
    {
        public void Configure(EntityTypeBuilder<FeatureTestProfile> builder)
        {
            builder.ToTable("feature_test_user");

            builder.HasOne(ftu => ftu.TestProfile)
                .WithMany()
                .HasForeignKey(ftu => ftu.TestProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ftu => ftu.ChatFeature)
                .WithMany()
                .HasForeignKey(ftu => ftu.ChatFeatureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasKey(ur => new { ur.TestProfileId, ur.ChatFeatureId });
        }
    }
}
