using API.Chats.Application.Features.Ollama.Models;

namespace API.Chats.Application.Features.Ollama.Client
{
    public interface IOllamaChatClient
    {
        Task<string> CompleteChatAsync(
            IReadOnlyList<OllamaConversationMessage> messages,
            CancellationToken cancellationToken);
    }
}
