using API.Shared.Domain.Base;

namespace API.Chats.Domain.Aggregates
{
    public enum MessageType
    {
        Normal = 0,
        AgentMessage = 1,
    }

    public class Message : AuditableSoftDeleteAggregateRoot
    {
        private Message()
        {   
        }

        private Message(string textContent, string chatId, MessageType messageType)
        {
            TextContent = textContent;
            ChatId = chatId;
            MessageType = messageType;
        }

        public string TextContent { get; set; }
        public MessageType MessageType { get; set; }
        public string? ParticipantId { get; set; }
        public string ChatId { get; private set; }

        public static Message Create(string textContent, string chatId, MessageType messageType = MessageType.Normal)
        {
            return new Message(textContent, chatId, messageType);
        }
    }
}
