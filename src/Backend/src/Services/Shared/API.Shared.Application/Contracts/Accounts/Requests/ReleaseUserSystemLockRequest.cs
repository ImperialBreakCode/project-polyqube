namespace API.Shared.Application.Contracts.Accounts.Requests
{
    public record ReleaseUserSystemLockRequest(string UserId)
    {
        public static ReleaseUserSystemLockRequest Create(string userId)
        {
            return new ReleaseUserSystemLockRequest(userId);
        }
    }
}
