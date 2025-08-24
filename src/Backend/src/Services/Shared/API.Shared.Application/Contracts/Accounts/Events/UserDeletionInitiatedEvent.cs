namespace API.Shared.Application.Contracts.Accounts.Events
{
    public record UserDeletionInitiatedEvent(string UserId, string Email);
}
