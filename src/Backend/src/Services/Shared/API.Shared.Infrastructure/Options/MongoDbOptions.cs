using System.ComponentModel.DataAnnotations;

namespace API.Shared.Infrastructure.Options
{
    public record MongoDbOptions
    {
        [Required]
        public string ConnectionString { get; set; }
    }
}
