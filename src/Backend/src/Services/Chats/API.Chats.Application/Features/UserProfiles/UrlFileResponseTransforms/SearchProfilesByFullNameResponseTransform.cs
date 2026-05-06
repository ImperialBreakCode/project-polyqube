using API.Chats.Application.Features.UserProfiles.Queries.SearchProfilesByFullName;
using API.Shared.Application.Contracts.FileStorage.Requests;
using API.Shared.Application.FileUrlTransform;
using API.Shared.Domain.CacheEntities.FileStorage;
using API.Shared.Domain.Interfaces.CacheRepo;
using MassTransit;

namespace API.Chats.Application.Features.UserProfiles.UrlFileResponseTransforms
{
    internal class SearchProfilesByFullNameResponseTransform(
        IRequestClient<GenerateAccountsFileUrlRequest> requestClient,
        IReadCacheRepository<FilePathCache> readFileCacheRepository)
        : FileUrlTransformer<SearchProfilesByFullNameResponse>(requestClient, readFileCacheRepository)
    {
        public override async Task InterceptAndProcessResponse(SearchProfilesByFullNameResponse model)
        {
            foreach (var profile in model.Profiles)
            {
                if (profile.ProfilePicture is not null)
                {
                    profile.ProfilePicture = await GetUrlPath(profile.ProfilePicture);
                }
            }
        }
    }
}
