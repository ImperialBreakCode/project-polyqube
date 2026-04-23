namespace API.Chats.Application.Features.Chats.Models
{
    public record ChatViewModel(
        string Id,
        bool IsGroupChat,
        bool AIEnabled
    )
    {
        public string? ChatName { get; set; }
    };
}
