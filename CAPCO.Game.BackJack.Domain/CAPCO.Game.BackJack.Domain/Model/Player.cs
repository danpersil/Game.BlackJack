using System.Collections.Generic;
using System.Linq;

namespace CAPCO.Game.BackJack.Domain.Model
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public int Score { get; set; }

        public Player(string name)
        {
            Cards = new List<Card>();
            Score = 0;
            Name = name;
        }

        public int GetCurrentScore()
        {
            return Cards.Sum(x => x.CardValue);
        }
    }
}
