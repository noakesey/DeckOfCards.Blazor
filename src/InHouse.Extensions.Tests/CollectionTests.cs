using NUnit.Framework;
using System.Collections.Generic;
using InHouse.Extensions;

namespace InHouse.Extensions.Tests
{
    public class CollectionTests
    {
        [Test]
        public void Shuffle_StringsInAList_AtLeastOneItemChangesPosition()
        {
            // Arrange
            List<string> unshuffled = new List<string> { "A", "B", "C", "D", "E" };

            // Act
            List<string> shuffled = (List<string>)unshuffled.Shuffle();

            var unShuffledString = string.Concat(unshuffled);
            var shuffledString = string.Concat(shuffled);

            // Assert
            Assert.AreNotEqual(unShuffledString, shuffledString);

        }
    }
}