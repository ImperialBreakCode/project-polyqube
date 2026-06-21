using API.Chats.Application.Features.UserProfiles.Commands.CreateUserProfile;

namespace API.Chats.Application.Features.UserProfiles.Factories
{
    internal class UserProfileCommandFactory : IUserProfileCommandFactory
    {
        public CreateUserProfileCommand CreateUserProfileCommand(string userId)
        {
            return new CreateUserProfileCommand(userId);
        }
    }
}
