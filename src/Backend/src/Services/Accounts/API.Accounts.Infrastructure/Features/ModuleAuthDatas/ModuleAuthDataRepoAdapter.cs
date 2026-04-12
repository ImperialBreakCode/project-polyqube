using API.Accounts.Domain.CacheEntities;
using API.Accounts.Domain.Repositories;
using API.Shared.Domain.Interfaces.CacheRepo;

namespace API.Accounts.Infrastructure.Features.ModuleAuthDatas
{
    internal class ModuleAuthDataRepoAdapter : IModuleAuthDataRepository
    {
        private readonly ICacheRepository<ModuleAuthData> _cacheRepository;

        public ModuleAuthDataRepoAdapter(ICacheRepository<ModuleAuthData> cacheRepository)
        {
            _cacheRepository = cacheRepository;
        }

        public void DeleteAuthModuleData(string code)
        {
            _cacheRepository.Delete(code);
        }

        public ModuleAuthData? GetAuthModuleData(string code)
        {
            return _cacheRepository.Get(code);
        }

        public void SetAuthModuleData(ModuleAuthData authModuleData)
        {
            _cacheRepository.Set(authModuleData.Code, authModuleData, authModuleData.Expiration);
        }
    }
}
