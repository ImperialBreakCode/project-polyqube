namespace API.Shared.Domain.Interfaces.CacheRepo
{
    public interface IReadCacheRepository<T>
        where T : class
    {
        T? Get(string key);
    }
}
