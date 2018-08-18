using CAPCO.Game.BackJack.Application.Interface;
using CAPCO.Game.BackJack.Domain.Model;
using Microsoft.Extensions.Caching.Memory;

namespace CAPCO.Game.BackJack.Application.App
{
    public class CacheApp : ICacheSetting
    {
        private IMemoryCache _cache;

        public CacheApp(IMemoryCache cache)
        {
            _cache = cache;
        }

        public string CreateCache(GameSession _input)
        {
            var cacheKey = string.Format("{0}{1}", CacheKeys.GameSession, _input.GetConfigKey());

            string gameInfo = "";

            if (!_cache.TryGetValue(cacheKey, out gameInfo))
                _cache.Set(cacheKey, _input.GameInfo);

            return cacheKey;
        }

        public string GetCache(string key)
        {
            var cacheReturn = "";
            _cache.TryGetValue(key, out cacheReturn);
            return cacheReturn;
        }

        public string UpdateCache(GameSession _input)
        {
            var cacheKey = string.Format("{0}{1}", CacheKeys.GameSession, _input.GetConfigKey());

            string gameInfo = "";

            if (_cache.TryGetValue(cacheKey, out gameInfo))
                _cache.Set(cacheKey, _input.GameInfo);

            return cacheKey;
        }
    }
}
