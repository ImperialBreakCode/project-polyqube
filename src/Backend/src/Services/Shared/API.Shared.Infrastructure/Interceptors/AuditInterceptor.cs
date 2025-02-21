using API.Shared.Domain.Interfaces.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace API.Shared.Infrastructure.Interceptors
{
    internal class AuditInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            if (eventData.Context is not null)
            {
                var changeTracker = eventData.Context.ChangeTracker;

                SetCreatedAtTimestamp(changeTracker);
                SetUpdatedAtTimestamp(changeTracker);
            }

            return base.SavingChanges(eventData, result);
        }

        private void SetCreatedAtTimestamp(ChangeTracker changeTracker)
        {
            var createdEntities = changeTracker
                    .Entries<ICreatedAtAuditable>()
                    .Where(e => e.State == EntityState.Added);

            foreach (var entity in createdEntities)
            {
                var timestamp = entity.Entity.SetCreatedAtTimestamp();

                if (entity.Entity is IAuditable auditableEntity)
                {
                    auditableEntity.UpdatedAt = timestamp;
                }
            }
        }

        private void SetUpdatedAtTimestamp(ChangeTracker changeTracker)
        {
            var updatedEntities = changeTracker
                    .Entries<IAuditable>()
                    .Where(e => e.State == EntityState.Modified);

            foreach (var entity in updatedEntities)
            {
                entity.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
