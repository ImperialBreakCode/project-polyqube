using System.ComponentModel.DataAnnotations;

namespace API.Shared.Application.Options
{
    internal record RabbitMqOptions
    {
        [Required]
        public string Host { get; init; }

        [Required]
        public string Username { get; init; }

        [Required]
        public string Password { get; init; }
    }
}
