using System.ComponentModel.DataAnnotations;

namespace API.Chats.Application.Features.Ollama.Options
{
    public class OllamaOptions
    {
        [Required]
        public string BaseUrl { get; set; } = "http://127.0.0.1:11434";

        [Required]
        public string Model { get; set; } = "llama3.2";
    }
}
