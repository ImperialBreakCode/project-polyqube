namespace API.Chats.Application.Features.Ollama.Models
{
    public class OllamaConversationMessage
    {
        public OllamaConversationMessage(string role, string content)
        {
            Role = role;
            Content = content;
        }

        public string Role { get; }

        public string Content { get; }
    }
}
