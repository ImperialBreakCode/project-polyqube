using API.Shared.Domain.Interfaces.Entity;

namespace API.Shared.Domain.Base
{
    public abstract class AuditableSoftDeleteAggregateRoot : AuditableAggregateRoot, ISoftDeletable
    {
        public DateTime? DeletedAt { get; private set; }

        public virtual void SoftDelete()
        {
            DeletedAt = DateTime.UtcNow;
        }

        public virtual void UndoSoftDelete()
        {
            DeletedAt = null;
        }
    }
}
