using CAPCO.Game.BackJack.Application.Interface;
using CAPCO.Game.BackJack.Domain.Model;
using System.Linq;

namespace CAPCO.Game.BackJack.Application.App
{
    public class GameApp : IGameApp
    {
        public int CheckScore(GameTable table)
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
            currentGame.GameTable = currentGame.GameTable.UpdateTable();

            return currentGame;
        }

        public GameTable NextTurn(GameTable table, Deck currentDeck, bool needCard)
        {
            Card selectedCard = null;

            if (needCard)
            {
                selectedCard = currentDeck.GetCardFromDeck();
                selectedCard.Shown = true;
                table.Player.Cards.Add(selectedCard);
            }

            Card hiddenCard = table.Dealer.Cards.FirstOrDefault(x => !x.Shown);

            if (hiddenCard == null)
            {
                selectedCard = currentDeck.GetCardFromDeck();
                selectedCard.Shown = true;
                table.Dealer.Cards.Add(selectedCard);
            }
            else
                hiddenCard.Shown = true;


            return table.UpdateTable();
        }
    }
}
