using CAPCO.Game.BackJack.Application.Interface;
using CAPCO.Game.BackJack.Domain.Model;

namespace CAPCO.Game.BackJack.Application.App
{
    public class GameApp : IGameApp
    {
        public int CheckScore(GameTable table, int player = 1)
        {
            throw new System.NotImplementedException();
        }

        public bool EndGame(GameTable table)
        {
            throw new System.NotImplementedException();
        }

        public GameInfo NewGame(string user, ICache _cache)
        {
            Deck currentDeck = new Deck();
            GameTable currentTable = new GameTable();

            GameInfo currentGame = new GameInfo(currentDeck);
            currentGame.GameTable = currentTable.CreateGameTable(currentDeck, user);
            currentGame.Key = _cache.CreateCache(new GameSession(currentGame, "01", user));
            currentGame.CurrentDeck = null;

            currentGame.GameTable = currentGame.GameTable.UpdateTable();

            return currentGame;
        }

        public GameTable NextTurn(GameTable table, Deck currentDeck)
        {
            Card selectedCar = currentDeck.GetCardFromDeck();
            table.Player.Cards.Add(selectedCar);

            return table.UpdateTable();
        }
    }
}
