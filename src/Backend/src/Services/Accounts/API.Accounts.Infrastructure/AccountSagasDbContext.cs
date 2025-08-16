using MassTransit.EntityFrameworkCoreIntegration;
using Microsoft.EntityFrameworkCore;

namespace API.Accounts.Infrastructure
{
    public class AccountSagasDbContext : SagaDbContext
    {
        public AccountSagasDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override IEnumerable<ISagaClassMap> Configurations => [];
    }
}
