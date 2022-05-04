namespace Interview.Application.Abstractions
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key);
        Task AddAsync(string key, object data);
        Task RemoveAsync(string key);
        void Clear();
        Task<bool> AnyAsync(string key);
    }
}
