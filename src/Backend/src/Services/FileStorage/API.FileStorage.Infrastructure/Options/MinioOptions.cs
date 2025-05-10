using System.ComponentModel.DataAnnotations;

namespace API.FileStorage.Infrastructure.Options
{
    internal record MinioOptions
    {
        [Required]
        public string Endpoint { get; set; }

        [Required]
        public string AccessKey { get; set; }

        [Required]
        public string SecretKey { get; set; }
    }
}
