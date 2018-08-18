using CAPCO.Game.BackJack.Domain.Model;

namespace CAPCO.Game.BackJack.Application.Interface
{
    public interface ICacheSetting
    {
        string CreateCache(GameSession _input);
        string GetCache(string key);
        string UpdateCache(GameSession _input);
    }
}
