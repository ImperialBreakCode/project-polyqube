namespace API.Chats.Application.Features.Ollama.Models
{
    public class GenerateOllamaAgentReplyResult
    {
        public GenerateOllamaAgentReplyResult(string replyText, string chatAgentId)
        {
            ReplyText = replyText;
            ChatAgentId = chatAgentId;
        }

        public string ReplyText { get; }

        public string ChatAgentId { get; }
    }
}
