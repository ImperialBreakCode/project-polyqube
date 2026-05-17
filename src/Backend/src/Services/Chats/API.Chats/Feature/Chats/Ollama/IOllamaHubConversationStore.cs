using API.Chats.Application.Features.Ollama.Models;

namespace API.Chats.Feature.Chats.Ollama
{
    /// <summary>
    ///     Per SignalR connection (and chat) in-memory turns sent to Ollama. Cleared on join and disconnect.
    /// </summary>
    public interface IOllamaHubConversationStore
    {
        void ResetSession(string connectionId, string chatId);

        void AppendUserMessage(string connectionId, string chatId, string content);

        void AppendAssistantMessage(string connectionId, string chatId, string content);

        IReadOnlyList<OllamaConversationMessage> GetConversation(string connectionId, string chatId);

        void ClearConnection(string connectionId);

        void RemoveSession(string connectionId, string chatId);
    }
}
