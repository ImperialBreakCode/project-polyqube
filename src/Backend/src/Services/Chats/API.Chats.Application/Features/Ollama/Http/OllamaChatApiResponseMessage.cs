namespace API.Chats.Application.Features.Ollama.Http
{
    public sealed class OllamaChatApiResponseMessage
    {
        public string? Role { get; set; }

        public string? Content { get; set; }
    }
}
