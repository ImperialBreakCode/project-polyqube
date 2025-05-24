using API.Accounts.Domain.Aggregates.UserAggregate;

namespace API.Accounts.Application.Features.Users.Models
{
    public record UserDetailsViewModel(
        string FirstName, 
        string LastName, 
        DateOnly Birthdate, 
        GenderEnum Gender, 
        DateTime CreatedAt,
        DateTime UpdatedAt
    )
    {
        public string? ProfilePicturePath { get; set; }
    }
}
