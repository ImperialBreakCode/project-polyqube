namespace API.Chats.Application.Features.Ollama.Http
{
    public class OllamaChatApiRequest
    {
        public OllamaChatApiRequest(string model, IReadOnlyList<OllamaChatApiMessage> messages, bool stream)
        {
            Model = model;
            Messages = messages.ToList();
            Stream = stream;
        }

        public string Model { get; }

        public IReadOnlyList<OllamaChatApiMessage> Messages { get; }

        public bool Stream { get; }
    }
}
