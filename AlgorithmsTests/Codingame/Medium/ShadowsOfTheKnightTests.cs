using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Medium.ShadowsOfTheKnight1;

[TestClass]
public class ShadowsOfTheKnight1Tests
{
    [TestMethod]
    [DataRow(4, 8, 2, 3, 40, 3, 7)]
    [DataRow(25, 33, 2, 29, 49, 24, 2)]
    [DataRow(40, 60, 6, 6, 32, 38, 38)]
    [DataRow(1, 80, 0, 1, 6, 0, 36)]
    [DataRow(50, 50, 0, 0, 6, 22, 22)]
    [DataRow(100, 100, 5, 98, 7, 0, 2)]
    [DataRow(9999, 9999, 54, 77, 14, 9733, 2532)]
    public void GetMoves_WhenCalled_PerformsCorrectly(int width, int height, int startX, int startY, int nbMovesAllowed, int bombX, int bombY)
    {
        // Arrange
        ShadowsOfTheKnight1 shadowsOfTheKnight1 = new();

        // Act
        var actual = shadowsOfTheKnight1.GetMoves(width, height, startX, startY, nbMovesAllowed, new AutomatedInput(bombX, bombY));

        // Assert
        actual.Last().Should().Be($"{bombX} {bombY}");
    }

}
