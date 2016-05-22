using System.Linq;

namespace _08.HandsOfCards
{
    public class CardParser
    {
        public Card ParseCard(string cardInfo)
        {
            return new Card(cardInfo.Last(), GetPower(cardInfo));
        }

        private static int GetPower(string cardInfo)
        {
            return char.IsLetter(cardInfo[0]) ? 
                CalculateCardPowerForLetter(cardInfo[0]) : 
                int.Parse(new string(cardInfo.Where(char.IsNumber).ToArray()));
        }

        private static int CalculateCardPowerForLetter(char cardLetter)
        {
            switch (cardLetter)
            {
                case 'J':
                    return 11;
                case 'Q':
                    return 12;
                case 'K':
                    return 13;
                case 'A':
                    return 14;
                default:
                    return -1;
            }
        }
    }
}