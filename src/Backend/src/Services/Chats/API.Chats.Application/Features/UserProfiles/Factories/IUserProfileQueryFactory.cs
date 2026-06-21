using API.Chats.Application.Features.UserProfiles.Queries.GetProfileByUserId;
using API.Chats.Application.Features.UserProfiles.Queries.SearchProfilesByFullName;

namespace API.Chats.Application.Features.UserProfiles.Factories
{
    public interface IUserProfileQueryFactory
    {
        GetProfileByUserIdQuery CreateGetProfileByUserIdQuery(string userId);
        SearchProfilesByFullNameQuery CreateSearchProfilesByFullNameQuery(string profileName, string currentProfileId, int count = 10);
    }
}
