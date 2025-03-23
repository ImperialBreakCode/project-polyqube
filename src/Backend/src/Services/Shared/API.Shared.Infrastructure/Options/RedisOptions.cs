using System.ComponentModel.DataAnnotations;

namespace API.Shared.Infrastructure.Options
{
    internal record RedisOptions
    {
        [Required]
        public string RedisHost { get; set; }
    }
}
