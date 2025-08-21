namespace API.Shared.Application.Contracts.Accounts.Responses
{
    public record UserSystemLockedResponse(string UserId)
    {
        public static UserSystemLockedResponse Create(string userId)
        {
            return new UserSystemLockedResponse(userId);
        }
    }
}
