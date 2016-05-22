using System.Collections.Generic;
using System.Linq;

namespace _08.HandsOfCards
{
    public class CardHandParser
    {
        private readonly CardParser _cardParser =
            new CardParser();

        public IEnumerable<Card> ParseCardHand(string cardHandInfo)
        {
            return cardHandInfo.Replace(" ", "").Split(',')
                .Select(_cardParser.ParseCard);
        }
    }
}