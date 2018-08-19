using System.Collections.Generic;

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
            bool changeValue = false;
            int totalSum = 0;

            List<Card> shownCards = Cards.FindAll(x => x.Shown);

            changeValue = shownCards.FindAll(x => x.CardValue == 10).Count > 0;

            foreach (var item in shownCards)
            {
                if (changeValue && item.Type == Enum.CardTypeEnum.Card_7)
                    totalSum += 11;
                else
                    totalSum += item.CardValue;
            }

            return totalSum;
        }
    }
}
