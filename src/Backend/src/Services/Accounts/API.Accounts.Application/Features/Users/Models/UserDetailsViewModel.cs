using API.Accounts.Domain.Aggregates.UserAggregate;

namespace API.Accounts.Application.Features.Users.Models
{
    public record UserDetailsViewModel(
        string FirstName, 
        string LastName, 
        DateOnly Birthdate, 
        GenderEnum Gender, 
        string? ProfilePicturePath,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
