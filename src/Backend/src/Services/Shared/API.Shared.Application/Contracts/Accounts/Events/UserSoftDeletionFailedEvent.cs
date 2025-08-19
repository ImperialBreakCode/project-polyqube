namespace API.Shared.Application.Contracts.Accounts.Events
{
    public record UserSoftDeletionFailedEvent(string UserId, string Email);
}
