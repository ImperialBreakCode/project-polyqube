namespace API.Shared.Domain.Interfaces.CacheRepo
{
    public interface ICacheRepository<T> : IReadCacheRepository<T>
        where T : class
    {
        void Set(string key, T value, DateTimeOffset timeOffset);
        void Delete(string key);
        void DeleteMultiple(string[] keys);
    }
}
