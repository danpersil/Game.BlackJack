using System.Runtime.Serialization;

namespace CAPCO.Game.BackJack.Domain.Model
{
    public class GameInfo
    {
        public string Key { get; set; }
        public GameTable GameTable { get; set; }


        [IgnoreDataMember]
        public Deck CurrentDeck { get; set; }

        public GameInfo(Deck currentDeck)
        {
            CurrentDeck = currentDeck;
        }


    }

}
