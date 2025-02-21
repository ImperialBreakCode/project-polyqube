using API.Shared.Domain.Interfaces.Entity;
using System.ComponentModel.DataAnnotations;

namespace API.Shared.Domain.Base.Entity
{
    public abstract class BaseEntity : IEntity
    {
        [Key]
        public string Id { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
