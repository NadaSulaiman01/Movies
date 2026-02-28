using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Movies.Services.Cache_Service
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDistributedCache _cache;
        private static readonly Random _random = new();

        public RedisCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var data = await _cache.GetStringAsync(key);
            if (data == null)
                return default;

            return JsonSerializer.Deserialize<T>(data);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan ttl)
        {
            // Add jitter (0–20% extra)
            var jitter = TimeSpan.FromSeconds(
                ttl.TotalSeconds * 0.2 * _random.NextDouble());

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = ttl + jitter
            };

            var json = JsonSerializer.Serialize(value);

            await _cache.SetStringAsync(key, json, options);
        }

        public Task RemoveAsync(string key)
            => _cache.RemoveAsync(key);

        public async Task<long> GetVersionAsync(string versionKey)
        {
            var value = await _cache.GetStringAsync(versionKey);
            return value == null ? 1 : long.Parse(value);
        }

        public async Task IncrementVersionAsync(string versionKey)
        {
            var current = await GetVersionAsync(versionKey);
            await _cache.SetStringAsync(versionKey, (current + 1).ToString());
        }
    }
}
