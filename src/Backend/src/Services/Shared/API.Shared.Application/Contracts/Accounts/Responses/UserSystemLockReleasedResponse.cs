namespace API.Shared.Application.Contracts.Accounts.Responses
{
    public record UserSystemLockReleasedResponse(string UserId)
    {
        public static UserSystemLockReleasedResponse Create(string userId)
        {
            return new UserSystemLockReleasedResponse(userId);
        }
    }
}
