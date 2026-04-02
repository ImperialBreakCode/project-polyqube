using API.Shared.Domain.Base;

namespace API.Chats.Domain.Aggregates
{
    public enum MessageType
    {
        Normal = 0
    }

    public class Message : AuditableSoftDeleteAggregateRoot
    {
        private Message()
        {   
        }

        private Message(string textContent, string chatId)
        {
            TextContent = textContent;
            ChatId = chatId;
        }

        public string TextContent { get; set; }
        public MessageType MessageType { get; set; }
        public string? ParticipantId { get; set; }
        public string ChatId { get; set; }

        public static Message Create(string textContent, string chatId)
        {
            return new Message(textContent, chatId);
        }
    }
}
