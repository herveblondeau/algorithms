using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Hard.Hangman
{
    [TestClass]
    public class HangmanTests
    {

        [TestMethod]
        [DataRow("hangman", new char[] { 'a', 'e', 's', 'm', 'g', 'n', 'h' }, 2)]
        public void Solve_GuessesWord_PerformsCorrectly(string word, char[] guesses, int expectedTurn)
        {
            // Arrange
            Hangman hangman = new();

            // Act
            var actual = hangman.Solve(word, guesses);

            // Assert
            Assert.AreEqual(expectedTurn, actual.NbFails);
            Assert.AreEqual(word, actual.Word);
        }
    }
}
