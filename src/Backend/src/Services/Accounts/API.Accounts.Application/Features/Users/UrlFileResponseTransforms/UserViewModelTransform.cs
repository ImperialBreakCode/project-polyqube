using API.Accounts.Application.Features.Users.Models;
using API.Shared.Application.Contracts.FileStorage.Requests;
using API.Shared.Application.FileUrlTransform;
using API.Shared.Domain.CacheEntities.FileStorage;
using API.Shared.Domain.Interfaces.CacheRepo;
using MassTransit;

namespace API.Accounts.Application.Features.Users.UrlFileResponseTransforms
{
    internal class UserViewModelTransform(IRequestClient<GenerateAccountsFileUrlRequest> requestClient, IReadCacheRepository<FilePathCache> readFileCacheRepository)
        : FileUrlTransformer<UserViewModel>(requestClient, readFileCacheRepository)
    {
        public async override Task InterceptAndProcessResponse(UserViewModel model)
        {
            if (model.UserDetails is not null && model.UserDetails.ProfilePicturePath is not null)
            {
                model.UserDetails.ProfilePicturePath = await GetUrlPath(model.UserDetails.ProfilePicturePath);
            }
        }
    }
}
