using CAPCO.Game.BackJack.Application.Interface;
using CAPCO.Game.BackJack.Domain.Model;
using Microsoft.Extensions.Caching.Memory;

namespace CAPCO.Game.BackJack.Application.App
{
    public class CacheApp : ICache
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
                _cache.Set(cacheKey, _input);

            return cacheKey;
        }

        public GameSession GetCache(string key)
        {
            _cache.TryGetValue(key, out GameSession gameInfo);
            return gameInfo;
        }

        public GameSession UpdateCache(GameSession _input)
        {
            var cacheKey = string.Format("{0}{1}", CacheKeys.GameSession, _input.GetConfigKey());

            if (_cache.TryGetValue(cacheKey, out GameSession gameInfo))
                _cache.Set(cacheKey, _input);

            return gameInfo;
        }
    }
}
