using API.Chats.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Chats.Infrastructure.Features.ChatFeatures
{
    internal class ChatFeatureConfig : IEntityTypeConfiguration<ChatFeature>
    {
        public void Configure(EntityTypeBuilder<ChatFeature> builder)
        {
            builder.ToTable("chat_feature");

            builder
                .HasIndex(x => x.FeatureName)
                .IsUnique();
        }
    }
}
