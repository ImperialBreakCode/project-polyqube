using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Admin.Infrastructure.Features.FeatureInfos
{
    internal class RestrictedUserConfig : IEntityTypeConfiguration<RestrictedUser>
    {
        public void Configure(EntityTypeBuilder<RestrictedUser> builder)
        {
            builder.ToTable("feature_restricted_users");

            builder
                .HasIndex(x => new { x.FeatureInfoId, x.RestrictedUserId })
                .IsUnique();

            builder
                .HasOne<FeatureInfo>()
                .WithMany()
                .HasForeignKey(x => x.FeatureInfoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
