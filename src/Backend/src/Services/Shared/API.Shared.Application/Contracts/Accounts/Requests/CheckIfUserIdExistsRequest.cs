namespace API.Shared.Application.Contracts.Accounts.Requests
{
    public record CheckIfUserIdExistsRequest(string UserId)
    {
        public static CheckIfUserIdExistsRequest Create(string userId) => new(userId);
    }
}
