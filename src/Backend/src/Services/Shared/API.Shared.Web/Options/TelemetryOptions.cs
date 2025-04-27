using System.ComponentModel.DataAnnotations;

namespace API.Shared.Web.Options
{
    public record TelemetryOptions
    {
        [Required]
        public string TempoEndpoint { get; set; }
    }
}
