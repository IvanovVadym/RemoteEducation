using Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Cache
{
    public class ApplicationCache<T>: IApplicationCache<T>
    {
        private readonly IMemoryCache _memoryCache;

        public ApplicationCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get(int key)
        {
            return _memoryCache.Get<T>(GetCacheKey(key));
        }

        public void Set(int key, T value)
        {
            _memoryCache.Set(GetCacheKey(key), value);
        }

        public void Remove(int key)
        {
            _memoryCache.Remove(GetCacheKey(key));
        }

        private string GetCacheKey(int key)
        {
            return $"{typeof(T).FullName}_{key}";
        }
    }
}
