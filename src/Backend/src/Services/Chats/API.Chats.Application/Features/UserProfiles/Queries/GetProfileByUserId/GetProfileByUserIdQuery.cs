using API.Chats.Application.Features.UserProfiles.Models;
using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.UserProfiles.Queries.GetProfileByUserId
{
    public record GetProfileByUserIdQuery(string UserId) : IQuery<UserProfileViewModel>;
}
