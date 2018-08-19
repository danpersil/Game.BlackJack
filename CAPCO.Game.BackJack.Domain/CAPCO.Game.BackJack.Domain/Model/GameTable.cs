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
            Card card1 = currentDeck.GetCardFromDeck();
            card1.Shown = true;
            Card card2 = currentDeck.GetCardFromDeck();
            card1.Shown = true;

            player1.Cards.Add(card1);
            player1.Cards.Add(card2);

            currentTable.Player = player1;

            //Dealer 1
            Player dealer = new Player("Dealer_" + userName);
            Card cardD1 = currentDeck.GetCardFromDeck();
            Card cardD2 = currentDeck.GetCardFromDeck();

            if (cardD1.CardValue == 10) cardD2.Shown = true;
            if (cardD2.CardValue == 10) cardD1.Shown = true;

            dealer.Cards.Add(cardD1);
            dealer.Cards.Add(cardD2);

            currentTable.Dealer = dealer;

            return currentTable;
        }

        public GameTable UpdateTable()
        {
            int playerScore = Player.Score = Player.GetCurrentScore();
            int dealerScore = Dealer.Score = Dealer.GetCurrentScore();

            if (playerScore >= 21 && dealerScore < 21)
                GameResult = GameResultEnum.WIN;
            if (playerScore == dealerScore)
                GameResult = GameResultEnum.DRAW;
            if (dealerScore >= 21 && playerScore < 21)
                GameResult = GameResultEnum.LOSE;

            return this;
        }
    }
}
