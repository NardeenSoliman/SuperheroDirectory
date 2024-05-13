using Microsoft.Extensions.Caching.Memory;
using SuperheroDirectory.Application.Caching;

namespace SuperheroDirectory.Infrastructure.Caching
{
    public class SystemCache : ISystemCache
    {
        private readonly IMemoryCache _cache;

        public SystemCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void Set<TItem>(string key, TItem value)
        {
            _cache.Set(key, value);
        }

        public TItem Get<TItem>(string key)
        {
            return _cache.Get<TItem>(key);
        }
    }
}