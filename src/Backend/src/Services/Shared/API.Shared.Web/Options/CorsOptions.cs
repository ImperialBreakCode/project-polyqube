using System.ComponentModel.DataAnnotations;

namespace API.Shared.Web.Options
{
    public record CorsOptions
    {
        [Required]
        public string[] AllowedOrigins { get; set; } = [];
    }
}
