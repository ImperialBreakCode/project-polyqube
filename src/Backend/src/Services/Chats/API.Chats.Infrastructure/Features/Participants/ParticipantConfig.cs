using API.Chats.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Chats.Infrastructure.Features.Participants
{
    internal class ParticipantConfig : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("participant");

            builder
                .HasOne(p => p.UserProfile)
                .WithMany()
                .HasForeignKey(p => p.UserProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.ChatAgent)
                .WithMany()
                .HasForeignKey(p => p.ChatAgentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.Chat)
                .WithMany()
                .HasForeignKey(p => p.ChatId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany<Message>()
                .WithOne()
                .HasForeignKey(m => m.ParticipantId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
