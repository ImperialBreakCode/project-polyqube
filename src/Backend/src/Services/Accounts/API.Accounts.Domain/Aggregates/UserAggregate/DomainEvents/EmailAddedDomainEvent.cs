using API.Shared.Domain.Interfaces;

namespace API.Accounts.Domain.Aggregates.UserAggregate.DomainEvents
{
    public record EmailAddedDomainEvent(string UserId, string Email) : IDomainEvent;
}
