using CAPCO.Game.BackJack.Domain.Model;

namespace CAPCO.Game.BackJack.Infra.Interface
{
    public interface ICacheInfra
    {
        string CreateCache(GameSession _input);
        GameSession GetCache(string key);
        GameSession UpdateCache(GameSession _input);
        void RemoveAllCache();
    }
}
