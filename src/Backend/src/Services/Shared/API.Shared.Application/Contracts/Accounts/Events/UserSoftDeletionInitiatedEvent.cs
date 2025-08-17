namespace API.Shared.Application.Contracts.Accounts.Events
{
    public record UserSoftDeletionInitiatedEvent(string UserId, string Email);
}
