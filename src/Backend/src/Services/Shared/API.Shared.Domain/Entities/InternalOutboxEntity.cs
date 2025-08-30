using API.Shared.Domain.Base.Entity;

namespace API.Shared.Domain.Entities
{
    public class InternalOutboxEntity : BaseCreatedAtEntity
    {
        private InternalOutboxEntity() { }

        private InternalOutboxEntity(string content, string type)
        {
            Content = content;
            Type = type;
        }

        public string Content { get; set; }
        public string Type { get; set; }
        public string? LockId { get; set; }

        public static InternalOutboxEntity Create(string content, string type)
        {
            return new InternalOutboxEntity(content, type);
        }
    }
}
