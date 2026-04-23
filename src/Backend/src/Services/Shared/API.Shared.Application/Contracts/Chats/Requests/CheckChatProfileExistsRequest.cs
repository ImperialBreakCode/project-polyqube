namespace API.Shared.Application.Contracts.Chats.Requests
{
    public record CheckChatProfileExistsRequest(string UserId)
    {
        public static CheckChatProfileExistsRequest Create(string userId) => new(userId);
    }
}
