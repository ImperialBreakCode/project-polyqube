using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using API.Shared.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace API.Admin.Infrastructure
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options)
            : base(options)
        {
        }

        public DbSet<FeatureInfo> FeatureInfos { get; set; }
        public DbSet<RestrictedUser> RestrictedUsers { get; set; }
        public DbSet<TestUser> TestUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var currentAssembly = typeof(AdminDbContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);

            modelBuilder.AddBusInboxOutbox();
        }
    }
}
