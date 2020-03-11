using Bunit;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace DeckOfCards.Client.Tests
{
    /// <summary>
    /// Headless UI/scenario tests
    /// </summary>
    public class CardsComponentTests : ComponentTestFixture
    {
        [Test(Description = "Tests that cards are named correctly")]
        public void Cards_MultipleCards_NamedCorrectly()
        {
            // Arrange
            var cards = new List<DeckOfCards.Shared.Card>();
            cards.Add(new DeckOfCards.Shared.Card { Suit = "Spades", Value = "Ace" });
            cards.Add(new DeckOfCards.Shared.Card { Suit = "Hearts", Value = "Queen" });

            // Act
            var sut = RenderComponent<Shared.Cards>((nameof(Shared.Cards.cards), cards));

            // Assert
            Assert.IsTrue(sut.Markup.Contains("Ace of Spades"));
            Assert.IsTrue(sut.Markup.Contains("Queen of Hearts"));
        }

        [Test(Description = "Tests that the generated image uri is formed corectly")]
        public void Cards_SingleCard_ImageUriFormedCorrectly()
        {
            // Arrange
            var card = new DeckOfCards.Shared.Card { Suit = "Spades", Value = "Ace" };

            var sut = new DeckOfCards.Client.Shared.Cards();

            // Act
            string actual = sut.cardFileName(card);

            // Assert
            Assert.AreEqual(@"img/cards/AS.svg", actual);

        }
    }
}