using API.Chats.Domain.Aggregates;
using API.Chats.Domain.Aggregates.UserProfilesAggregate;
using API.Shared.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace API.Chats.Infrastructure
{
    public class ChatDbContext : DbContext
    {
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatAgent> ChatAgents { get; set; }
        public DbSet<ChatFeature> ChatFeatures { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Participant> Participant { get; set; }

        public DbSet<FeatureRestrictedProfile> FeatureRestrictedProfiles { get; set; }
        public DbSet<FeatureTestProfile> FeatureTestProfile { get; set; }
        public DbSet<BlockedProfile> BlockedProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var currentAssembly = typeof(ChatDbContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);

            modelBuilder.AddBusInboxOutbox();
            modelBuilder.AddInternalOutbox();
        }
    }
}
