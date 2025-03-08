using API.Accounts.Domain.Aggregates.UserAggregate;

namespace API.Accounts.Features.Users.Models.Responses
{
    public record UserDetailsResponseDTO(
        string FirstName,
        string LastName,
        DateOnly Birthdate,
        GenderEnum Gender,
        string? ProfilePicturePath,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
