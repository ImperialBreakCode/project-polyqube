using System.ComponentModel.DataAnnotations;

namespace API.Shared.Infrastructure.Options
{
    public record RedisOptions
    {
        [Required]
        public string RedisHost { get; init; }
    }
}
