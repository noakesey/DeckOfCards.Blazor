using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DeckOfCards.Client.Pages
{
    public partial class Index : ComponentBase
    {
        /// <summary>
        /// Fetch the deck if it isn't already created
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            if (AppData.Deck == null)
            {
                await Reset();
            }
        }

        /// <summary>
        /// Reset the deck by requesting a new stack of cards
        /// </summary>
        /// <returns></returns>
        private async Task Reset()
        {
            try
            {
                AppData.Deck = await Http.GetJsonAsync<Stack<DeckOfCards.Shared.Card>>("Deck");
            }
            catch 
            {
                //Create a default, empty deck
                AppData.Deck = new Stack<DeckOfCards.Shared.Card>();
            }

            AppData.Players.Clear();
            AppData.InProgress = false;

            AddPlayer();
        }

        /// <summary>
        /// Shuffle the deck by requesting a new, shuffled, stack of cards
        /// </summary>
        /// <returns></returns>
        private async Task Shuffle()
        {
            try
            {
                AppData.Deck = await Http.GetJsonAsync<Stack<DeckOfCards.Shared.Card>>("Deck?shuffle=true");
            }
            catch
            {
                //Create a default, empty deck
                AppData.Deck = new Stack<DeckOfCards.Shared.Card>();
            }
        }

        /// <summary>
        /// Add a new player
        /// </summary>
        private void AddPlayer()
        {
            var player = new DeckOfCards.Shared.Player();
            player.Name = $"Player {AppData.Players.Count + 1}";

            AppData.Players.Add(player);
        }

        /// <summary>
        /// Deal a round of cards to the players
        /// </summary>
        private void Deal()
        {
            foreach (DeckOfCards.Shared.Player player in AppData.Players)
            {
                AppData.Deal(player);
            }

            AppData.InProgress = true;
        }
    }
}
