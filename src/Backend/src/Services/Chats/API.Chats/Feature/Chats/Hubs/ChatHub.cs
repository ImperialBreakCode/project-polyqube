using Microsoft.AspNetCore.SignalR;

namespace API.Chats.Feature.Chats.Hubs
{
    // placeholder chat hub
    public class ChatHub : Hub
    {
        public async Task JoinChat(string chatId)
        {
            // check if chat exists, then connect

            await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        }

        public async Task LeaveChat(string chatId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chatId);
        }

        // Send message to a specific chat
        public async Task SendMessageToChat(string chatId, string user, string message)
        {
            await Clients.Group(chatId)
                .SendAsync("ReceiveMessage", chatId, user, message);
        }
    }
}
