using API.Shared.Domain.Interfaces.Entity;

namespace API.Shared.Domain.Interfaces
{
    public interface IAggregateRoot : IEntity
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void ClearDomainEvents();
    }
}
