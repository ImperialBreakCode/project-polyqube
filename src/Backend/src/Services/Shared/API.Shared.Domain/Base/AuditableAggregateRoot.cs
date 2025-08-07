using API.Shared.Domain.Base.Entity;
using API.Shared.Domain.Interfaces;
using API.Shared.Domain.Interfaces.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Shared.Domain.Base
{
    public abstract class AuditableAggregateRoot : BaseCreatedAtEntity, IAuditable, IAggregateRoot
    {
        [NotMapped]
        private readonly ICollection<IDomainEvent> _domainEvents;

        protected AuditableAggregateRoot()
        {
            _domainEvents = [];
        }

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList();

        public DateTime UpdatedAt { get; set; }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
