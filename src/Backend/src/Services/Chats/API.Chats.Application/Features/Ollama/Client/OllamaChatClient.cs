using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using API.Chats.Application.Features.Ollama.Http;
using API.Chats.Application.Features.Ollama.Models;
using API.Chats.Application.Features.Ollama.Options;
using Microsoft.Extensions.Options;

namespace API.Chats.Application.Features.Ollama.Client
{
    public sealed class OllamaChatClient : IOllamaChatClient
    {
        private static readonly JsonSerializerOptions SerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };

        private readonly HttpClient _httpClient;
        private readonly OllamaOptions _options;

        public OllamaChatClient(HttpClient httpClient, IOptions<OllamaOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
        }

        public async Task<string> CompleteChatAsync(
            IReadOnlyList<OllamaConversationMessage> messages,
            CancellationToken cancellationToken)
        {
            var apiMessages = messages
                .Select(m => new OllamaChatApiMessage(m.Role, m.Content))
                .ToList();

            var payload = new OllamaChatApiRequest(_options.Model, apiMessages, false);

            using var response = await _httpClient.PostAsJsonAsync("api/chat", payload, SerializerOptions, cancellationToken);
            var body = await response.Content.ReadAsStringAsync(cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"Ollama request failed ({(int)response.StatusCode}): {body}");
            }

            var parsed = JsonSerializer.Deserialize<OllamaChatApiResponse>(body, SerializerOptions);
            var content = parsed?.Message?.Content;
            if (string.IsNullOrWhiteSpace(content))
            {
                throw new InvalidOperationException("Ollama returned no assistant content.");
            }

            return content;
        }
    }
}
