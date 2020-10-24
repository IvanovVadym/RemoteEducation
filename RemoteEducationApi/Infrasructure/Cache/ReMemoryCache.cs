using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Cache
{
    class ReMemoryCache<T> : IReMemoryCache<T>
    {
        private readonly IMemoryCache _memoryCache;

        public ReMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T SetValue(int id, T value)
        {
            return _memoryCache.Set(GetCacheKey(id), value);
        }

        public T GetValue(int id)
        {
            return _memoryCache.Get<T>(GetCacheKey(id));
        }

        public void RemoveValue(int id)
        {
            _memoryCache.Remove(GetCacheKey(id));
        }

        private string GetCacheKey(int id)
        {
            return $"{typeof(T).FullName}_{id}";
        }
    }
}