﻿using API.Shared.Domain.Base.Entity;
using API.Shared.Domain.Interfaces;
using API.Shared.Domain.Interfaces.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Shared.Domain.Base
{
    public abstract class AuditableSoftDeleteAggregateRoot : BaseCreatedAtEntity, IAuditable, ISoftDeletable, IAggregateRoot
    {
        [NotMapped]
        private readonly ICollection<IDomainEvent> _domainEvents;

        protected AuditableSoftDeleteAggregateRoot()
        {
            _domainEvents = [];
        }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList();

        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; private set; }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public virtual void SoftDelete()
        {
            DeletedAt = DateTime.UtcNow;
        }

        public virtual void UndoSoftDelete()
        {
            DeletedAt = null;
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
