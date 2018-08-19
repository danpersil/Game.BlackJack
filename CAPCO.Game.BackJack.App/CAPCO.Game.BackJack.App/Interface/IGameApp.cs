using CAPCO.Game.BackJack.Domain.Model;

namespace CAPCO.Game.BackJack.Application.Interface
{
    public interface IGameApp
    {
        int CheckScore(GameTable table, int player = 1);
        bool EndGame(GameTable table);
        GameInfo NewGame(string user, ICache _cache);
        GameTable NextTurn(GameTable table, Deck currentDeck);
    }
}
