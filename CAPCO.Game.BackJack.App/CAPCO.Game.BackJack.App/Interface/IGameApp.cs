using CAPCO.Game.BackJack.Domain.Model;

namespace CAPCO.Game.BackJack.Application.Interface
{
    public interface IGameApp
    {
        GameInfo NewGame(string user);
        GameTable NextTurn(GameTable table, Deck currentDeck, bool needCard);
        void EndGame();
    }
}
