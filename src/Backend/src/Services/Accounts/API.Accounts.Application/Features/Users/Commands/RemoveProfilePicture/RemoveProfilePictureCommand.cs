using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.RemoveProfilePicture
{
    public record RemoveProfilePictureCommand(string UserId) : ICommand;
}
