using System.Collections.Concurrent;
using API.Chats.Application.Features.Ollama.Models;

namespace API.Chats.Feature.Chats.Ollama
{
    internal sealed class OllamaHubConversationStore : IOllamaHubConversationStore
    {
        private const char KeySeparator = '\u001f';

        private readonly ConcurrentDictionary<string, List<OllamaConversationMessage>> _sessions = new();

        public void ResetSession(string connectionId, string chatId)
        {
            _sessions[MakeKey(connectionId, chatId)] = [];
        }

        public void AppendUserMessage(string connectionId, string chatId, string content)
        {
            var list = GetOrCreateList(connectionId, chatId);
            lock (list)
            {
                list.Add(new OllamaConversationMessage("user", content));
            }
        }

        public void AppendAssistantMessage(string connectionId, string chatId, string content)
        {
            var list = GetOrCreateList(connectionId, chatId);
            lock (list)
            {
                list.Add(new OllamaConversationMessage("assistant", content));
            }
        }

        public IReadOnlyList<OllamaConversationMessage> GetConversation(string connectionId, string chatId)
        {
            var key = MakeKey(connectionId, chatId);
            if (!_sessions.TryGetValue(key, out var list))
            {
                return [];
            }

            lock (list)
            {
                return list.ToArray();
            }
        }

        public void ClearConnection(string connectionId)
        {
            var prefix = connectionId + KeySeparator;
            foreach (var key in _sessions.Keys.ToArray())
            {
                if (key.StartsWith(prefix, StringComparison.Ordinal))
                {
                    _sessions.TryRemove(key, out _);
                }
            }
        }

        public void RemoveSession(string connectionId, string chatId)
        {
            _sessions.TryRemove(MakeKey(connectionId, chatId), out _);
        }

        private List<OllamaConversationMessage> GetOrCreateList(string connectionId, string chatId)
        {
            var key = MakeKey(connectionId, chatId);
            return _sessions.GetOrAdd(key, _ => new List<OllamaConversationMessage>());
        }

        private static string MakeKey(string connectionId, string chatId)
            => connectionId + KeySeparator + chatId;
    }
}
