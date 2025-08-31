using API.Shared.Domain.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace API.Shared.Infrastructure.Extensions
{
    public static class DbContextExtensions
    {
        public static void AddBusInboxOutbox(this ModelBuilder modelBuilder)
        {
            modelBuilder.AddOutboxStateEntity();
            modelBuilder.AddInboxStateEntity();
            modelBuilder.AddOutboxMessageEntity();
        }

        public static void AddInternalOutbox(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InternalOutboxEntity>(builder =>
            {
                builder.ToTable("internal_outbox");
            });
        }
    }
}
