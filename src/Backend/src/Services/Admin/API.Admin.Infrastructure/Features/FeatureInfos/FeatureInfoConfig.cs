using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Admin.Infrastructure.Features.FeatureInfos
{
    internal class FeatureInfoConfig : IEntityTypeConfiguration<FeatureInfo>
    {
        public void Configure(EntityTypeBuilder<FeatureInfo> builder)
        {
            builder.ToTable("feature_infos");

            builder.OwnsMany(fi => fi.RestrictedUsers, ownedBuilder =>
            {
                ownedBuilder
                    .HasIndex(ru => ru.RestrictedUserId)
                    .IsUnique();

                ownedBuilder.ToTable("feature_restricted_users");
            });

            builder.OwnsMany(fi => fi.TestUsers, ownedBuilder =>
            {
                ownedBuilder
                    .HasIndex(tu => tu.TestUserId)
                    .IsUnique();

                ownedBuilder.ToTable("feature_test_users");
            });
        }
    }
}
