using System.ComponentModel.DataAnnotations;

namespace API.Shared.Infrastructure.Options
{
    public record SagasDbOptions
    {
        [Required]
        public string ConnectionString { get; init; }
    }
}
