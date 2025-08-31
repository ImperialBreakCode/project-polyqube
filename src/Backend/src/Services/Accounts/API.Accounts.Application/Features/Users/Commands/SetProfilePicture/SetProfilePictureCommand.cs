using API.Shared.Application.Interfaces;

namespace API.Accounts.Application.Features.Users.Commands.SetProfilePicture
{
    public record SetProfilePictureCommand(Stream Stream, string FileName, string UserId) : ICommand;
}
