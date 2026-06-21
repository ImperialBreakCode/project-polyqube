using API.Chats.Application.Features.Ollama.Models;
using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.Ollama.Commands.GenerateOllamaAgentReply
{
    public record GenerateOllamaAgentReplyCommand(
        string ChatId,
        IReadOnlyList<OllamaConversationMessage> ConversationMessages)
        : ICommand<GenerateOllamaAgentReplyResult>;
}
