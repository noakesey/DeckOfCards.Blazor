using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Shared
{
    /// <summary>
    /// This class serves as a domain (Data Transfer Object) for representing the deck to the client.
    /// </summary>
    public class Card
    {
        //The order of card suits is from the specification, rather than the standard order (Spades, Hearts, Diamonds, Clubs)
        public static readonly string[] Suits = new[]
        {
            "Hearts", "Diamonds", "Clubs", "Spades"
        };

        //The order of card values is from the specification, rather than the standard order (Ace, 2, 3, 4 etc..)
        public static readonly string[] Values = new[]
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King", "Ace"
        };

        public string Suit { get; set; }

        public string Value { get; set; }
    }
}
