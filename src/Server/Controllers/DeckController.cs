using DeckOfCards.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InHouse.Extensions;

namespace DeckOfCards.Server.Controllers
{

    /*
    Complex business logic is performed by the server and exposed via an API as it may 
    potentially be reused / orchestrated by other processes in the future.

    This API can be tested in isolation from the UI
    */

    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly ILogger<DeckController> logger;

        public DeckController(ILogger<DeckController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// The user can only shuffle when there are still 52 cards in the deck, so the client only needs
        /// one operation for retrieving the deck and it is unshuffled by default.
        /// </summary>
        /// <param name="shuffle"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Card> Get(bool shuffle)
        {
            //Realworld scenarios might come from SQL Server etc..
            var deck = from suit in Card.Suits.Reverse()
                       from value in Card.Values.Reverse()
                       select new Card
                       {
                           Suit = suit,
                           Value = value
                       };


            //reuse some complex business logic developed and tested by a different 
            //project and distributed via package (could also be another service).
            if (shuffle)
            {
                //Shuffling once from an ordered deck may not result in enough randomness
                //Could pass the number of times to shuffle from the client
                var shuffled = deck.Shuffle();

                return shuffled;
            }

            return deck;
        }
    }
}
