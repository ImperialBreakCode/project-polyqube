namespace API.Shared.Application.Contracts.Accounts.Events
{
    public record UserSoftDeletedEvent(string UserId, string Email);
}
