namespace Movies.Services.Cache_Service
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, TimeSpan ttl);
        Task RemoveAsync(string key);

        // Versioning helpers
        Task<long> GetVersionAsync(string versionKey);
        Task IncrementVersionAsync(string versionKey);
    }
}
