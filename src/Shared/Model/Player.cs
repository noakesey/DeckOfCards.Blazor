using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Shared
{
    /// <summary>
    /// This class represents the cards held by a player, and might be used by the server in the future.
    /// </summary>
    public class Player
    {
        public Player()
        {
            Cards = new List<Card>();
        }

        public string Name { get; set; }

        public IList<Card> Cards { get; set; }
    }
}
