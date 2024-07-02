using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Medium.Blunder1;

[TestClass]
public class BlunderTests
{
    [TestMethod]
    [DataRow(new string[] { "######", "#@E $#", "# N  #", "#X   #", "######" }, new string[] { "SOUTH", "EAST", "NORTH", "EAST", "EAST" }, "")]
    [DataRow(new string[] { "##########", "#        #", "#  S   W #", "#        #", "#  $     #", "#        #", "#@       #", "#        #", "#E     N #", "##########" }, new string[] { "SOUTH", "SOUTH", "EAST", "EAST", "EAST", "EAST", "EAST", "EAST", "NORTH", "NORTH", "NORTH", "NORTH", "NORTH", "NORTH", "WEST", "WEST", "WEST", "WEST", "SOUTH", "SOUTH" }, "")]
    public void Traverse_NoInfiniteLoop_ReturnsPath(string[] rows, string[] expectedPath, string dummy)
    {
        // Arrange
        Blunder1 blunder = new();

        // Act
        var result = blunder.Traverse(rows);

        // Assert
        result.IsStuckInInfiniteLoop.Should().BeFalse();
        result.Path.Should().Equal(expectedPath);
    }

    [TestMethod]
    [DataRow(new string[] { "###############", "#      IXXXXX #", "#  @          #", "#E S          #", "#             #", "#  I          #", "#  B          #", "#  B   S     W#", "#  B   T      #", "#             #", "#         T   #", "#         B   #", "#N          W$#", "#        XXXX #", "###############" })]
    public void Traverse_InfiniteLoop_ReturnsLoop(string[] rows)
    {
        // Arrange
        Blunder1 blunder = new();

        // Act
        var result = blunder.Traverse(rows);

        // Assert
        result.IsStuckInInfiniteLoop.Should().BeTrue();
    }
}
