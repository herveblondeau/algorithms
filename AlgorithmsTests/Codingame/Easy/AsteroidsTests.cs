using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Easy.Asteroids;

[TestClass]
public class AsteroidsTests
{

    [TestMethod]
    public void GetState3_HorizontalMotion_PerformsCorrectly()
    {
        // Arrange
        Asteroids Asteroids = new();
        char[][] state1 = [
            ['A', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];
        char[][] state2 = [
            ['.', 'A', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];

        // Act
        var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

        // Assert
        char[][] expected = [
            ['.', '.', 'A', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void GetState3_VerticalMotion_PerformsCorrectly()
    {
        // Arrange
        Asteroids Asteroids = new();
        char[][] state1 = [
            ['A', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];
        char[][] state2 = [
            ['.', '.', '.', '.', '.'],
            ['A', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];

        // Act
        var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

        // Assert
        char[][] expected = [
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['A', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void GetState3_CombinedMotion_PerformsCorrectly()
    {
        // Arrange
        Asteroids Asteroids = new();
        char[][] state1 = [
            ['A', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];
        char[][] state2 = [
            ['.', '.', '.', '.', '.'],
            ['.', 'A', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];

        // Act
        var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

        // Assert
        char[][] expected = [
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', 'A', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void GetState3_NegativeMotion_PerformsCorrectly()
    {
        // Arrange
        Asteroids Asteroids = new();
        char[][] state1 = [
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', 'A', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];
        char[][] state2 = [
            ['.', '.', '.', '.', '.'],
            ['.', 'A', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];

        // Act
        var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

        // Assert
        char[][] expected = [
            ['A', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
        ];
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void GetState3_GreaterDelta_PerformsCorrectly()
    {
        // Arrange
        Asteroids Asteroids = new();
        char[][] state1 = [
            ['A', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
        ];
        char[][] state2 = [
            ['.', '.', '.', '.', 'A', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
        ];

        // Act
        var actual = Asteroids.GetState3(1, state1, 5, state2, 6);

        // Assert
        char[][] expected = [
            ['.', '.', '.', '.', '.', 'A'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
        ];
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void GetState3_MultipleAsteroids_PerformsCorrectly()
    {
        // Arrange
        Asteroids Asteroids = new();
        char[][] state1 = [
            ['A', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['B', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
        ];
        char[][] state2 = [
            ['.', 'A', '.', '.', '.', '.'],
            ['B', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
        ];

        // Act
        var actual = Asteroids.GetState3(1, state1, 3, state2, 5);

        // Assert
        char[][] expected = [
            ['B', '.', 'A', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
        ];
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void GetState3_NoMotion_PerformsCorrectly()
    {
        // Arrange
        Asteroids Asteroids = new();
        char[][] state1 = [
            ['.', '.', '.', '.', '.'],
            ['.', 'A', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', 'D', '.'],
            ['.', '.', '.', '.', '.'],
        ];
        char[][] state2 = [
            ['.', '.', '.', '.', '.'],
            ['.', 'A', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', 'D', '.'],
            ['.', '.', '.', '.', '.'],
        ];

        // Act
        var actual = Asteroids.GetState3(0, state1, 1255, state2, 9999);

        // Assert
        char[][] expected = [
            ['.', '.', '.', '.', '.'],
            ['.', 'A', '.', '.', '.'],
            ['.', '.', '.', '.', '.'],
            ['.', '.', '.', 'D', '.'],
            ['.', '.', '.', '.', '.'],
        ];
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void GetState3_Depth_PerformsCorrectly()
    {
        // Arrange
        Asteroids Asteroids = new();
        char[][] state1 = [
            ['.', '.', 'H', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['E', '.', '.', '.', 'G', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', 'F', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
        ];
        char[][] state2 = [
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', 'H', '.', '.', '.'],
            ['.', 'E', '.', 'G', '.', '.'],
            ['.', '.', 'F', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
        ];

        // Act
        var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

        // Assert
        char[][] expected = [
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', 'E', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
            ['.', '.', '.', '.', '.', '.'],
        ];
        actual.Should().BeEquivalentTo(expected);
    }

    [TestMethod]
    public void GetState3_OutOfBounds_PerformsCorrectly()
    {
        // Arrange
        Asteroids Asteroids = new();
        char[][] state1 = [
            ['A', '.', '.'],
            ['B', '.', '.'],
            ['C', '.', '.'],
        ];
        char[][] state2 = [
            ['B', 'A', '.'],
            ['.', '.', '.'],
            ['.', '.', 'C'],
        ];

        // Act
        var actual = Asteroids.GetState3(1, state1, 2, state2, 3);

        // Assert
        char[][] expected = [
            ['.', '.', 'A'],
            ['.', '.', '.'],
            ['.', '.', '.'],
        ];
        actual.Should().BeEquivalentTo(expected);
    }
}
