using Interview.Application.Abstractions;
using Newtonsoft.Json;

namespace Interview.Infrastructure.Persistence.Redis
{
    public class RedisCacheService : ICacheService
    {
        private readonly RedisServer _redisServer;

        public RedisCacheService(RedisServer redisServer)
        {
            _redisServer = redisServer;
        }

        public async Task AddAsync(string key, object data)
        {
            string jsonData = JsonConvert.SerializeObject(data);
            await _redisServer.Database.StringSetAsync(key, jsonData);
        }

        public async Task<bool> AnyAsync(string key)
        {
            return await _redisServer.Database.KeyExistsAsync(key);
        }

        public void Clear()
        {
            _redisServer.FlushDatabase();
        }

        public async Task<T> GetAsync<T>(string key)
        {
            if (await AnyAsync(key))
            {
                string jsonData = await _redisServer.Database.StringGetAsync(key);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return default;
        }

        public async Task RemoveAsync(string key)
        {
            await _redisServer.Database.KeyDeleteAsync(key);
        }
    }
}
