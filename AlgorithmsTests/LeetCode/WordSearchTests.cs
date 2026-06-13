using AwesomeAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.WordSearch;

[TestClass]
public class WordSearchTests
{
    private char[][] _board = {
            new char[] { 'A', 'B', 'C', 'E' },
            new char[] { 'S', 'F', 'C', 'S' },
            new char[] { 'A', 'D', 'E', 'E' },
        };

    [TestMethod]
    [DataRow("ABCCED")]
    [DataRow("SEE")]
    public void SearchWord_ShouldReturnTrue_WhenWordExistsInBoard(string word)
    {
        // Arrange
        var wordSearch = new WordSearch();

        // Act
        var actual = wordSearch.SearchWord(word, _board);

        // Assert
        actual.Should().BeTrue();
    }

    [TestMethod]
    [DataRow("ABCB")]
    public void SearchWord_ShouldReturnFalse_WhenWordDoesNotExistInBoard(string word)
    {
        // Arrange
        var wordSearch = new WordSearch();

        // Act
        var actual = wordSearch.SearchWord(word, _board);

        // Assert
        actual.Should().BeFalse();
    }
}
