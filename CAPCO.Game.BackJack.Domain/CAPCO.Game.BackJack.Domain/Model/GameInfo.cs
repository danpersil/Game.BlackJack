namespace CAPCO.Game.BackJack.Domain.Model
{
    public class GameInfo
    {
        public string Key { get; set; }
        public Deck CurrentDeck { get; set; }
        public GameTable GameTable { get; set; }

        public GameInfo(Deck currentDeck)
        {
            CurrentDeck = currentDeck;
        }


    }

}
