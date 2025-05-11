using System.ComponentModel.DataAnnotations;

namespace API.Shared.Application.Options
{
    internal record RabbitMqOptions
    {
        [Required]
        public string Host { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
