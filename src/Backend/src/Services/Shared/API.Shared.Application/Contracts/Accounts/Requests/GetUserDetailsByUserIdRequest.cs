namespace API.Shared.Application.Contracts.Accounts.Requests
{
    public record GetUserDetailsByUserIdRequest(string UserId)
    {
        public static GetUserDetailsByUserIdRequest Create(string userId) => new(userId);
    }
}
