using API.Accounts.Application.Features.Users.Commands.SetProfilePicture;

namespace API.Accounts.Application.Features.Users.Factories
{
    public interface IUserCommandFactory
    {
        SetProfilePictureCommand CreateSetProfilePictureCommand(Stream stream, string fileName, string mimeType, string userId);
    }
}
