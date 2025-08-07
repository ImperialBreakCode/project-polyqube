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

            builder
                .HasIndex(x => x.FeatureName)
                .IsUnique();
        }
    }
}
