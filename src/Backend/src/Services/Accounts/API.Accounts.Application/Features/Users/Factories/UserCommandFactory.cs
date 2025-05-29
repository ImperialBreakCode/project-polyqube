using API.Accounts.Application.Features.Users.Commands.RemoveProfilePicture;
using API.Accounts.Application.Features.Users.Commands.SetProfilePicture;

namespace API.Accounts.Application.Features.Users.Factories
{
    internal class UserCommandFactory : IUserCommandFactory
    {
        public RemoveProfilePictureCommand CreateRemoveProfilePictureCommand(string userId)
        {
            return new RemoveProfilePictureCommand(userId);
        }

        public SetProfilePictureCommand CreateSetProfilePictureCommand(Stream stream, string fileName, string userId)
        {
            return new SetProfilePictureCommand(stream, fileName, userId);
        }
    }
}
