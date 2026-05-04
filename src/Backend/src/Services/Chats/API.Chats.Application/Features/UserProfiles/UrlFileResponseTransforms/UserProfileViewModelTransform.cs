using API.Chats.Application.Features.UserProfiles.Models;
using API.Shared.Application.Contracts.FileStorage.Requests;
using API.Shared.Application.FileUrlTransform;
using API.Shared.Domain.CacheEntities.FileStorage;
using API.Shared.Domain.Interfaces.CacheRepo;
using MassTransit;

namespace API.Chats.Application.Features.UserProfiles.UrlFileResponseTransforms
{
    internal class UserProfileViewModelTransform(IRequestClient<GenerateAccountsFileUrlRequest> requestClient, IReadCacheRepository<FilePathCache> readFileCacheRepository) : FileUrlTransformer<UserProfileViewModel>(requestClient, readFileCacheRepository)
    {
        public override async Task InterceptAndProcessResponse(UserProfileViewModel model)
        {
            if (model.ProfilePicture is not null)
            {
                model.ProfilePicture = await GetUrlPath(model.ProfilePicture);
            }
        }
    }
}
