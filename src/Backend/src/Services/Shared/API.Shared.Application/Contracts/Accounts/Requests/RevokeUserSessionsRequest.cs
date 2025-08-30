namespace API.Shared.Application.Contracts.Accounts.Requests
{
    public record RevokeUserSessionsRequest(string UserId)
    {
        public static RevokeUserSessionsRequest Create(string userId)
        {
            return new RevokeUserSessionsRequest(userId);
        }
    }
}
