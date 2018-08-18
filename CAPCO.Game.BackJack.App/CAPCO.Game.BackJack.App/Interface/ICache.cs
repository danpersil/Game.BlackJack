using CAPCO.Game.BackJack.Domain.Model;

namespace CAPCO.Game.BackJack.Application.Interface
{
    public interface ICache
    {
        string CreateCache(GameSession _input);
        GameSession GetCache(string key);
        GameSession UpdateCache(GameSession _input);
    }
}
