using Newtonsoft.Json;
using StackExchange.Redis;

namespace CompanyAPI.RedisCache
{
    public class RedisCacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _redisCon;
        private readonly IDatabase _cache;

        public RedisCacheService(IConnectionMultiplexer redisCon)
        {
            _redisCon = redisCon;
            _cache = redisCon.GetDatabase();
        }

        public void Add(string key , object value , int duration = 5)
        {
            var result = JsonConvert.SerializeObject(value);
            _cache.StringSet(key, result , TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            var result = _cache.StringGet(key);
            return JsonConvert.DeserializeObject<T>(result);
        }

        public bool IsThere(string key)
        {
            return _cache.KeyExists(key);
        }
    }
}
