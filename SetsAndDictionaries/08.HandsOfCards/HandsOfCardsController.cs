using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.HandsOfCards
{
    public class HandsOfCardsController
    {
        private readonly CardHandParser _cardHandParser = 
            new CardHandParser();

        private readonly Dictionary<string, HashSet<Card>> _cardHands =
            new Dictionary<string, HashSet<Card>>();

        public void Run()
        {
            var cardHandInfo = Console.ReadLine();

            while (cardHandInfo != "JOKER")
            {
                var colonDelimeterIndex = cardHandInfo.IndexOf(':');
                var playerName = cardHandInfo.Substring(0, colonDelimeterIndex);
                var cardsInHand = cardHandInfo.Substring(colonDelimeterIndex + 2);

                var cardHand = _cardHandParser.ParseCardHand(cardsInHand);
                if (_cardHands.ContainsKey(playerName))
                {
                    _cardHands[playerName].UnionWith(cardHand);
                }
                else
                {
                    _cardHands.Add(playerName, new HashSet<Card>(cardHand));
                }

                cardHandInfo = Console.ReadLine();
            }

            PrintScores();
        }

        private void PrintScores()
        {
            foreach (var cardHand in _cardHands)
            {
                Console.WriteLine($"{cardHand.Key}: {cardHand.Value.Sum(card => card.CalculatePower())}");
            }
        }
    }
}