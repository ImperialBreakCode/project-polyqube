using API.Accounts.Domain.CacheEntities;

namespace API.Accounts.Domain.Repositories
{
    public interface IModuleAuthDataRepository
    {
        ModuleAuthData? GetAuthModuleData(string code);
        void SetAuthModuleData(ModuleAuthData authModuleData);
        void DeleteAuthModuleData(string code);
    }
}
