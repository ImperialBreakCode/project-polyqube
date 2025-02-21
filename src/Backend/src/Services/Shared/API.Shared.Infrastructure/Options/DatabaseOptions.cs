using System.ComponentModel.DataAnnotations;

namespace API.Shared.Infrastructure.Options
{
    internal class DatabaseOptions
    {
        [Required]
        public string ConnectionString { get; set; }
    }
}
