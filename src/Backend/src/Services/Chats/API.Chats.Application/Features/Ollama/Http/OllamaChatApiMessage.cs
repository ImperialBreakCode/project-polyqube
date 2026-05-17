namespace API.Chats.Application.Features.Ollama.Http
{
    public sealed class OllamaChatApiMessage
    {
        public OllamaChatApiMessage(string role, string content)
        {
            Role = role;
            Content = content;
        }

        public string Role { get; }

        public string Content { get; }
    }
}
