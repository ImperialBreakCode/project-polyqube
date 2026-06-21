using API.Shared.Domain.Base;

namespace API.Chats.Domain.Aggregates
{
    public class Chat: AuditableSoftDeleteAggregateRoot
    {
        private Chat()
        {
        }

        public string? ChatName { get; set; }
        public bool IsGroupChat { get; set; }
        public bool AIEnabled { get; set; }

        public static Chat Create()
        {
            return new Chat();
        }
    }
}
