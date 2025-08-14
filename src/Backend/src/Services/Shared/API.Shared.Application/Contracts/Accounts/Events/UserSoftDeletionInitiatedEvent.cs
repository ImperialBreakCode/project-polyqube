namespace API.Shared.Application.Contracts.Accounts.Events
{
    public record UserSoftDeletionInitiatedEvent(string UserId)
    {
        public static UserSoftDeletionInitiatedEvent Create(string UserId)
        {
            return new UserSoftDeletionInitiatedEvent(UserId);
        }
    }
}
