namespace API.Shared.Application.Contracts.Accounts.Responses
{
    public record UserSessionsRevokedResponse(string UserId)
    {
        public static UserSessionsRevokedResponse Create(string userId)
        {
            return new UserSessionsRevokedResponse(userId);
        }
    }
}
