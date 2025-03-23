namespace API.Shared.Domain.Interfaces
{
    public interface ICacheRepository<T> 
        where T : class
    {
        T? Get(string key);
        void Set(string key, T value, TimeSpan timeInterval);
        void Delete(string key);
        void DeleteMultiple(string[] keys);
    }
}
