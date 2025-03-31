using API.Accounts.Domain.Aggregates.UserAggregate;
using System.ComponentModel.DataAnnotations;

namespace API.Accounts.Features.Users.Models.Requests
{
    public record UpdateUserDetailsRequestDTO
    {
        [Required]
        public string FirstName { get; init; }

        [Required]
        public string LastName { get; init; }

        [Required]
        public DateOnly Birthdate { get; init; }

        [Required]
        public GenderEnum Gender { get; init; }
    }
}
