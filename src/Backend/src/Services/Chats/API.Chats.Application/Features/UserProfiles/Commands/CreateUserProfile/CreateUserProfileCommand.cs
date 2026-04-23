using API.Chats.Application.Features.UserProfiles.Models;
using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.UserProfiles.Commands.CreateUserProfile
{
    public record CreateUserProfileCommand(string UserId) : ICommand<UserProfileViewModel>;
}
