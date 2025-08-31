using API.Shared.Domain.Interfaces;

namespace API.Accounts.Domain.Aggregates.UserAggregate.DomainEvents
{
    public record UserCreatedDomainEvent(string UserId) : IDomainEvent;
}
