using API.Chats.Application.Features.UserProfiles.Commands.CreateUserProfile;

namespace API.Chats.Application.Features.UserProfiles.Factories
{
    public interface IUserProfileCommandFactory
    {
        CreateUserProfileCommand CreateUserProfileCommand(string userId);
    }
}
