using Bunit;
using DeckOfCards.Client.Services;
using NUnit.Framework;
using Shouldly;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace DeckOfCards.Client.Tests
{
    /// <summary>
    /// Headless UI/scenario tests
    /// </summary>
    public class IndexPageTests : ComponentTestFixture
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test(Description = "Tests that the shuffle button is enabled before dealing starts")]
        public void Index_DealingNotStarted_ShuffleButtonEnabled()
        {
            // Arrange
            Services.AddSingleton<AppData>();
            Services.AddSingleton<HttpClient>();

            // Act
            var sut = RenderComponent<Pages.Index>();

            // Assert
            //TODO This is fragile - find a better way to reference the element
            AngleSharp.Html.Dom.IHtmlButtonElement button =
                (AngleSharp.Html.Dom.IHtmlButtonElement)sut.Nodes[4].ChildNodes[1]; 

            Assert.IsFalse(button.IsDisabled);
        }

    }
}