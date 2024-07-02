using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Expert.UnfoldingPaper;

[TestClass]
public class UnfoldingPaperTests
{

    [TestMethod]
    [DataRow(1, 5)]
    [DataRow(2, 10)]
    [DataRow(5, 290)]
    public void Unfold_3x3FoldedPaper_PerformsCorrectly(int nbUnfoldings, int expected)
    {
        // Arrange
        UnfoldingPaper unfoldingPaper = new();
        string[] folded = new string[]
        {
            "###",
            "#..",
            "#.#"
        };

        // Act
        var actual = unfoldingPaper.Unfold(folded, nbUnfoldings);

        // Assert
        actual.Should().Be(expected);
    }

    [TestMethod]
    [DataRow(1)]
    [DataRow(5)]
    [DataRow(14)]
    [DataRow(10000)]
    public void Unfold_Full_AlwaysOne(int nbUnfoldings)
    {
        // Arrange
        UnfoldingPaper unfoldingPaper = new();
        string[] folded = new string[]
        {
            "###",
            "#.#",
            "###"
        };

        // Act
        var actual = unfoldingPaper.Unfold(folded, nbUnfoldings);

        // Assert
        actual.Should().Be(1);
    }
}
