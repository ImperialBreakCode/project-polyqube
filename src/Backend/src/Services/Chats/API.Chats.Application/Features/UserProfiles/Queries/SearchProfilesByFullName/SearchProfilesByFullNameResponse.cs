using API.Chats.Application.Features.UserProfiles.Models;
using API.Shared.Common.MediatorResponse;

namespace API.Chats.Application.Features.UserProfiles.Queries.SearchProfilesByFullName
{
    public record SearchProfilesByFullNameResponse(
        ICollection<UserProfileViewModel> Profiles) : IInterceptableResponse;
}
