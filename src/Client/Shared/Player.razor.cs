using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCards.Client.Shared
{
    public partial class Player : ComponentBase
    {
        [Parameter]
        public DeckOfCards.Shared.Player player { get; set; }
    }
}
