using CAPCO.Game.BackJack.Domain.Enum;

namespace CAPCO.Game.BackJack.Domain.Model
{
    public class GameTable
    {
        public Player Player { get; set; }
        public Player Dealer { get; set; }
        public GameResultEnum GameResult { get; set; }

        public GameTable()
        {
            GameResult = GameResultEnum.NORESULT;
        }


        public GameTable CreateGameTable(Deck currentDeck, string userName)
        {
            GameTable currentTable = new GameTable();

            //Player 1
            Player player1 = new Player(userName);
            Card card1 = currentDeck.GetCardFromDeck(currentDeck.Cards);
            currentDeck.Cards.Remove(card1);
            Card card2 = currentDeck.GetCardFromDeck(currentDeck.Cards);
            currentDeck.Cards.Remove(card2);

            player1.Cards.Add(card1);
            player1.Cards.Add(card2);

            currentTable.Player = player1;

            //Dealer 1
            Player dealer = new Player("Dealer_" + userName);
            Card cardD1 = currentDeck.GetCardFromDeck(currentDeck.Cards);
            currentDeck.Cards.Remove(cardD1);

            //One shwon card
            cardD1.Shown = true;

            Card cardD2 = currentDeck.GetCardFromDeck(currentDeck.Cards);
            currentDeck.Cards.Remove(cardD2);

            dealer.Cards.Add(cardD1);
            dealer.Cards.Add(cardD2);

            currentTable.Dealer = dealer;

            return currentTable;
        }
    }
}
