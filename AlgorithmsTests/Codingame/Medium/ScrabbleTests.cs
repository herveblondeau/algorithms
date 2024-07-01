using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Medium.Scrabble
{
    [TestClass]
    public class ScrabbleTests
    {

        [TestMethod]
        [DataRow(new string[] { "because", "first", "these", "could", "which" }, "hicquwh", "which")]
        [DataRow(new string[] { "some", "first", "potsie", "day", "could", "postie", "from", "have", "back", "this" }, "sopitez", "potsie")]
        [DataRow(new string[] { "after", "repots", "user", "powers", "these", "time", "know", "from", "could", "people" }, "tsropwe", "powers")]
        [DataRow(new string[] { "after", "repots", "poowers", "powers", "these", "time", "know", "from", "could", "people" }, "tsropwe", "powers")]
        [DataRow(new string[] { "qzyoq", "azejuy", "kqjsdh", "aeiou", "qsjkdh" }, "qzaeiou", "aeiou")]
        [DataRow(new string[] { "arrest", "rarest", "raster", "raters", "sartre", "starer", "waster", "waters", "wrest", "wrase" }, "arwtsre", "waster")]
        public void FindBestWord_WhenCalled_PerformsCorrectly(string[] words, string letters, string expected)
        {
            // Arrange
            Scrabble scrabbleSolver = new();

            // Act
            var actual = scrabbleSolver.FindBestWord(words, letters);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
