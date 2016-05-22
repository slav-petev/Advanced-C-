using System;
using System.Collections.Generic;

namespace _08.HandsOfCards
{
    public class Card : IEquatable<Card>
    {
        private static readonly Dictionary<char, int> _suitePowers =
            new Dictionary<char, int>
            {
                { 'S', 4 },
                { 'H', 3 },
                { 'D', 2 },
                { 'C', 1 }
            };

        public char Suite { get; }
        public int Power { get; }

        public Card(char suite, int power)
        {
            Suite = suite;
            Power = power;
        }

        public int CalculatePower()
        {
            return Power * _suitePowers[Suite];
        }

        #region Overrides of Object

        public override int GetHashCode()
        {
            return Suite.GetHashCode() ^ Power;
        }

        public override bool Equals(object obj)
        {
            var card = obj as Card;
            return card != null && Equals(card);
        }

        #endregion

        #region Implementation of IEquatable<Card>

        public bool Equals(Card other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Suite == other.Suite && Power == other.Power;
        }

        #endregion
    }
}