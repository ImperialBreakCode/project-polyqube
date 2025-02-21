using API.Shared.Domain.Interfaces.Entity;

namespace API.Shared.Domain.Base.Entity
{
    public abstract class BaseCreatedAtEntity : BaseEntity, ICreatedAtAuditable
    {
        public DateTime CreatedAt { get; protected set; }

        public DateTime SetCreatedAtTimestamp()
        {
            if (CreatedAt == DateTime.MinValue)
            {
                CreatedAt = DateTime.UtcNow;
            }

            return CreatedAt;
        }
    }
}
