using API.Chats.Application.Features.UserProfiles.Queries.GetProfileByUserId;
using API.Chats.Application.Features.UserProfiles.Queries.SearchProfilesByFullName;

namespace API.Chats.Application.Features.UserProfiles.Factories
{
    internal class UserProfileQueryFactory : IUserProfileQueryFactory
    {
        public GetProfileByUserIdQuery CreateGetProfileByUserIdQuery(string userId)
        {
            return new GetProfileByUserIdQuery(userId);
        }

        public SearchProfilesByFullNameQuery CreateSearchProfilesByFullNameQuery(string profileName, string currentProfileId, int count = 10)
        {
            return new SearchProfilesByFullNameQuery(profileName, currentProfileId, count);
        }
    }
}
