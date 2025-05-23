using System.ComponentModel.DataAnnotations;

namespace API.Shared.Web.Options
{
    public record AuthValidationOptions
    {
        [Required]
        public string Authority { get; init; }

        [Required]
        public string AccessTokenValidationEndpoint { get; init; }
    }
}
