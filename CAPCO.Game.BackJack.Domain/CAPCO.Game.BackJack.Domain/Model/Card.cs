using CAPCO.Game.BackJack.Domain.Enum;

namespace CAPCO.Game.BackJack.Domain.Model
{
    public class Card
    {
        public CardTypeEnum Type { get; set; }
        public NaipeTypeEnum Naipe { get; set; }
        public bool ChangeValue { get; set; }
        public bool Shown { get; set; }
        public int CardValue
        {
            get
            {
                switch (Type)
                {
                    case CardTypeEnum.Card_A:
                        return 1;
                    case CardTypeEnum.Card_2:
                        return 2;
                    case CardTypeEnum.Card_3:
                        return 3;
                    case CardTypeEnum.Card_4:
                        return 4;
                    case CardTypeEnum.Card_5:
                        return 5;
                    case CardTypeEnum.Card_6:
                        return 6;
                    case CardTypeEnum.Card_7:
                        return 7;
                    case CardTypeEnum.Card_8:
                        return 8;
                    case CardTypeEnum.Card_9:
                        return 9;
                    case CardTypeEnum.Card_10:
                    case CardTypeEnum.Card_J:
                    case CardTypeEnum.Card_K:
                    case CardTypeEnum.Card_Q:
                        return 10;
                }
                return 0;
            }
        }

        public Card(CardTypeEnum type, NaipeTypeEnum naipe, bool changeValue = false)
        {
            Type = type;
            Naipe = naipe;
            ChangeValue = changeValue;
        }
    }
}
