namespace API.Shared.Application.Contracts.Accounts.Requests
{
    public record SystemLockUserRequest(string UserId)
    {
        public static SystemLockUserRequest Create(string userId)
        {
            return new SystemLockUserRequest(userId);
        }
    }
}
