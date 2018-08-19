using CAPCO.Game.BackJack.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CAPCO.Game.BackJack.Domain.Model
{
    public class Deck
    {
        public int DeckId { get; set; }
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = CreateDeck();
        }

        public List<Card> CreateDeck()
        {
            List<int> cardTypes = new List<int>();
            List<int> naipeTypes = new List<int>();

            foreach (int i in System.Enum.GetValues(typeof(CardTypeEnum))) cardTypes.Add(i);
            foreach (int x in System.Enum.GetValues(typeof(NaipeTypeEnum))) naipeTypes.Add(x);

            List<Card> cardsList = (from type in cardTypes
                                    from naipe in naipeTypes
                                    orderby naipe, type
                                    select new Card((CardTypeEnum)type, (NaipeTypeEnum)naipe, false)).ToList();

            Cards = cardsList;
            Cards = ShuffleDeck();
            return cardsList;
        }

        public List<Card> ShuffleDeck() => Cards.OrderBy(item => new Random().Next()).ToList();

        public Card GetCardFromDeck()
        {
            int r = new Random().Next(Cards.Count);
            Card selectedCard = Cards[r];
            Cards.Remove(selectedCard);
            return selectedCard;
        }
    }
}
