using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codingame.Hard.TheBurglarsDilemna;

[TestClass]
public class TheBurglarsDilemnaTests
{

    [TestMethod]
    public void Test1()
    {
        // Arrange
        TheBurglarsDilemna theBurglarsDilemna = new();
        List<Guess> guesses =
        [
            new Guess(1, 0, Sound.CLICK),
            new Guess(2, 1, Sound.CLICK),
            new Guess(3, 2, Sound.CLACK),
            new Guess(4, 3, Sound.CLUCK),
            new Guess(4, 2, Sound.CLUCK),
            new Guess(5, 3, Sound.CLICK),
            new Guess(8, 3, Sound.CLACK),
        ];

        // Act
        var actual = theBurglarsDilemna.Solve(4, guesses);

        // Assert
        string expected = "1 2 5 5";
        actual.Should().Be(expected);
    }

    [TestMethod]
    public void Test2()
    {
        // Arrange
        TheBurglarsDilemna theBurglarsDilemna = new();
        List<Guess> guesses =
        [
            new Guess(0, 0, Sound.CLUCK),
            new Guess(4, 0, Sound.CLUCK),
            new Guess(7, 0, Sound.CLUCK),
        ];

        // Act
        var actual = theBurglarsDilemna.Solve(1, guesses);

        // Assert
        string expected = "2";
        actual.Should().Be(expected);
    }

    [TestMethod]
    public void Test3()
    {
        // Arrange
        TheBurglarsDilemna theBurglarsDilemna = new();
        List<Guess> guesses =
        [
            new Guess(4, 0, Sound.CLUCK),
            new Guess(6, 0, Sound.CLUCK),
            new Guess(0, 0, Sound.CLACK),
            new Guess(9, 0, Sound.CLACK),
        ];

        // Act
        var actual = theBurglarsDilemna.Solve(1, guesses);

        // Assert
        string expected = "5";
        actual.Should().Be(expected);
    }
}
