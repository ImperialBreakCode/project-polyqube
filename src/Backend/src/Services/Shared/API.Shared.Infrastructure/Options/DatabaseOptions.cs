using System.ComponentModel.DataAnnotations;

namespace API.Shared.Infrastructure.Options
{
    internal record DatabaseOptions
    {
        [Required]
        public string ConnectionString { get; set; }
    }
}
