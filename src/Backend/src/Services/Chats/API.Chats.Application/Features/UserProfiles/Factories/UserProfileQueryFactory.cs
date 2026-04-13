using API.Chats.Application.Features.UserProfiles.Queries.GetProfileByUserId;

namespace API.Chats.Application.Features.UserProfiles.Factories
{
    internal class UserProfileQueryFactory : IUserProfileQueryFactory
    {
        public GetProfileByUserIdQuery CreateGetProfileByUserIdQuery(string userId)
        {
            return new GetProfileByUserIdQuery(userId);
        }
    }
}
