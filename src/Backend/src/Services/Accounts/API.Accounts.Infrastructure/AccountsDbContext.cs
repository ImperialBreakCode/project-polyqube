using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Accounts.Domain.SagaMachineDatas.UserSoftDelete;
using API.Shared.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace API.Accounts.Infrastructure
{
    public class AccountsDbContext : DbContext
    {
        public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserDeletionToken> UserDeletionTokens { get; set; }

        public DbSet<UserSoftDeleteSagaData> SoftDeleteSagaData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var currentAssembly = typeof(AccountsDbContext).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(currentAssembly);

            modelBuilder.AddBusInboxOutbox();
        }
    }
}
