using System.ComponentModel.DataAnnotations;

namespace API.Shared.Web.Options
{
    public record AuthValidationOptions
    {
        [Required]
        public string Authority { get; set; }

        [Required]
        public string AccessTokenValidationEndpoint { get; set; }
    }
}
