using API.Chats.Application.Features.UserProfiles.Queries.GetProfileByUserId;

namespace API.Chats.Application.Features.UserProfiles.Factories
{
    public interface IUserProfileQueryFactory
    {
        GetProfileByUserIdQuery CreateGetProfileByUserIdQuery(string userId);
    }
}
