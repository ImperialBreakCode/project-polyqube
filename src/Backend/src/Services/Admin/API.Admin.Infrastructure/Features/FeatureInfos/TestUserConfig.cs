using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Admin.Infrastructure.Features.FeatureInfos
{
    internal class TestUserConfig : IEntityTypeConfiguration<TestUser>
    {
        public void Configure(EntityTypeBuilder<TestUser> builder)
        {
            builder.ToTable("feature_test_users");

            builder
                .HasIndex(x => new { x.FeatureInfoId, x.TestUserId })
                .IsUnique();

            builder
                .HasOne<FeatureInfo>()
                .WithMany()
                .HasForeignKey(x => x.FeatureInfoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
