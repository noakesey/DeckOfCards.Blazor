using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCards.Client.Shared
{
    public partial class Cards : ComponentBase
    {
        [Parameter]
        public IEnumerable<DeckOfCards.Shared.Card> cards { get; set; }

        public string cardFileName(DeckOfCards.Shared.Card card)
        {
            return @"img/cards/" + card.Value[0] + card.Suit[0] + ".svg";
        }
    }
}
