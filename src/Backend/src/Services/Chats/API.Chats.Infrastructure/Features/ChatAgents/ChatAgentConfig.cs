using API.Chats.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Chats.Infrastructure.Features.ChatAgents
{
    internal class ChatAgentConfig : IEntityTypeConfiguration<ChatAgent>
    {
        public void Configure(EntityTypeBuilder<ChatAgent> builder)
        {
            builder.ToTable("chat_agent");

            builder
                .HasIndex(x => x.AgentUsername)
                .IsUnique();
        }
    }
}
