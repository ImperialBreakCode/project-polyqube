using API.Shared.Application.Interfaces;

namespace API.Chats.Application.Features.UserProfiles.Queries.SearchProfilesByFullName
{
    public record SearchProfilesByFullNameQuery(
        string ProfileName,
        string CurrentProfileId,
        int Count = 10) : IQuery<SearchProfilesByFullNameResponse>;
}
