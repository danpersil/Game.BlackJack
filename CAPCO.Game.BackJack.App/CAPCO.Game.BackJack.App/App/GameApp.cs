using CAPCO.Game.BackJack.Application.Interface;
using CAPCO.Game.BackJack.Domain.Model;
using CAPCO.Game.BackJack.Infra.Interface;
using System;
using System.Linq;

namespace CAPCO.Game.BackJack.Application.App
{
    public class GameApp : IGameApp
    {
        private readonly ICacheInfra _cache;

        public GameApp(ICacheInfra cache)
        {
            _cache = cache;
        }

        public GameInfo NewGame(string user)
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
            if (table.GameResult == Domain.Enum.GameResultEnum.NORESULT)
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
                    if (table.Dealer.Cards.Count() < 5 || table.Dealer.GetCurrentScore() <= 17)
                    {
                        Random rd = new Random();
                        selectedCard = currentDeck.GetCardFromDeck();
                        selectedCard.Shown = rd.Next(0, 2) > 0;
                        table.Dealer.Cards.Add(selectedCard);
                    }
                }
                else
                    hiddenCard.Shown = true;
            }

            return table.UpdateTable();
        }

        public void EndGame()
        {
            _cache.RemoveAllCache();
        }
    }
}
