using API.Admin.Domain.Aggregates.FeatureInfoAggregate;
using Microsoft.EntityFrameworkCore;

namespace API.Admin.Infrastructure
{
    internal class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options)
            : base(options)
        {
        }

        public DbSet<FeatureInfo> FeatureInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var currentAssembly = typeof(AdminDbContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);
        }
    }
}
