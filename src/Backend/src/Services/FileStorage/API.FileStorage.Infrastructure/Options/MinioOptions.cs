using System.ComponentModel.DataAnnotations;

namespace API.FileStorage.Infrastructure.Options
{
    internal record MinioOptions
    {
        [Required]
        public string Endpoint { get; init; }

        [Required]
        public string AccessKey { get; init; }

        [Required]
        public string SecretKey { get; init; }
    }
}
