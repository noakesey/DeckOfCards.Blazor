using DeckOfCards.Shared;
using System;
using System.Collections.Generic;

namespace DeckOfCards.Client.Services
{
    /// <summary>
    /// This class represents the shared state of the application in the client between pages and components.
    /// </summary>
    public class AppData
    {
        private IList<Player> _players;
        private Stack<Card> _deck;
        private bool _inProgress;

        public AppData()
        {
            _players = new List<Player>();
        }

        /// <summary>
        /// The players
        /// </summary>
        public IList<Player> Players
        {
            get
            {
                return _players;
            }
            set
            {
                _players = value;
                NotifyDataChanged();
            }
        }

        /// <summary>
        /// The deck of cards
        /// </summary>
        public Stack<Card> Deck
        {
            get
            {
                return _deck;
            }
            set
            {
                _deck = value;
                NotifyDataChanged();
            }
        }

        /// <summary>
        /// This mutates the state by popping a card from the deck 
        /// and adding it to the list of cards held by the player
        /// </summary>
        /// <param name="player"></param>
        public void Deal(Player player)
        {
            if (Deck.Count > 0)
            {
                player.Cards.Add(Deck.Pop());
            }

            NotifyDataChanged();
        }

        /// <summary>
        /// Certain actions are disabled once dealing is in progress.
        /// </summary>
        public bool InProgress
        {
            get
            {
                return _inProgress;
            }
            set
            {
                _inProgress = value;

                NotifyDataChanged();
            }
        }

        public event Action OnChange;

        private void NotifyDataChanged() => OnChange?.Invoke();
    }
}