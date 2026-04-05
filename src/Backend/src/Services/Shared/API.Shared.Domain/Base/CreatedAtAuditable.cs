using API.Shared.Domain.Interfaces.Entity;

namespace API.Shared.Domain.Base
{
    public class CreatedAtAuditable : ICreatedAtAuditable
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
