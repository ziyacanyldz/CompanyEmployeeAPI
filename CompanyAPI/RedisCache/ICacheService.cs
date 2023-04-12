namespace CompanyAPI.RedisCache
{
    public interface ICacheService
    {
        public void Add(string key, object value, int duration = 5);
        public T Get<T>(string key);
        public bool IsThere(string key);
    }
}
