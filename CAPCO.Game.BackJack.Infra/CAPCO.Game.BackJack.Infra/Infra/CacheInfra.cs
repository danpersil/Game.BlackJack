using CAPCO.Game.BackJack.Domain.Model;
using CAPCO.Game.BackJack.Infra.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace CAPCO.Game.BackJack.Infra.Infra
{
    public class CacheInfra : ICacheInfra
    {
        private IMemoryCache _cache;

        public CacheInfra(IMemoryCache cache)
        {
            _cache = cache;
        }

        public string CreateCache(GameSession _input)
        {
            var cacheKey = string.Format("{0}{1}", CacheKeys.GameSession, _input.GetConfigKey());

            if (!_cache.TryGetValue(cacheKey, out string gameInfo))
                _cache.Set(cacheKey, _input);

            return cacheKey;
        }

        public GameSession GetCache(string key)
        {
            _cache.TryGetValue(key, out GameSession gameInfo);
            return gameInfo;
        }

        public void RemoveAllCache()
        {
            _cache.Dispose();
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
