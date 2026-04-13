namespace API.Chats.Application.Features.Chats.Models
{
    public record ChatViewModel(
        string Id,
        string? ChatName,
        bool IsGroupChat,
        bool AIEnabled
    );
}
