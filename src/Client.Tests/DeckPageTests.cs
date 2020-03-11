using Bunit;
using DeckOfCards.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;
using System.Net.Http;

namespace DeckOfCards.Client.Tests
{
    /// <summary>
    /// Performance tests
    /// </summary>
    public class DeckPageTests : ComponentTestFixture
    {
        [Test(Description = "Tests that the shuffle button is not disabled before dealing starts")]
        public void Deck_UnshuffledDeckPerformance_Success()
        {
            // Arrange
            Services.AddSingleton<AppData>();
            Services.AddSingleton<HttpClient>();

            // Act
            var sut = RenderComponent<Pages.Deck>();

            // Assert

        }

    }
}