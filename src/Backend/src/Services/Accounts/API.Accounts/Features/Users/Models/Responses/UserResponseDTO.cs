namespace API.Accounts.Features.Users.Models.Responses
{
    public record UserResponseDTO(
        string Id,
        string Username,
        bool LockedOut,
        bool Disabled,
        bool Suspended,
        ICollection<UserEmailResponseDTO> Emails,
        UserDetailsResponseDTO? UserDetails,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
