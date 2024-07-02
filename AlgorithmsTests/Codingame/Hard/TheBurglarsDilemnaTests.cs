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
        List<Guess> guesses = new();
        guesses.Add(new Guess(1, 0, Sound.CLICK));
        guesses.Add(new Guess(2, 1, Sound.CLICK));
        guesses.Add(new Guess(3, 2, Sound.CLACK));
        guesses.Add(new Guess(4, 3, Sound.CLUCK));
        guesses.Add(new Guess(4, 2, Sound.CLUCK));
        guesses.Add(new Guess(5, 3, Sound.CLICK));
        guesses.Add(new Guess(8, 3, Sound.CLACK));

        // Act
        var actual = theBurglarsDilemna.Solve(4, guesses);

        // Assert
        string expected = "1 2 5 5";
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test2()
    {
        // Arrange
        TheBurglarsDilemna theBurglarsDilemna = new();
        List<Guess> guesses = new();
        guesses.Add(new Guess(0, 0, Sound.CLUCK));
        guesses.Add(new Guess(4, 0, Sound.CLUCK));
        guesses.Add(new Guess(7, 0, Sound.CLUCK));

        // Act
        var actual = theBurglarsDilemna.Solve(1, guesses);

        // Assert
        string expected = "2";
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test3()
    {
        // Arrange
        TheBurglarsDilemna theBurglarsDilemna = new();
        List<Guess> guesses = new();
        guesses.Add(new Guess(4, 0, Sound.CLUCK));
        guesses.Add(new Guess(6, 0, Sound.CLUCK));
        guesses.Add(new Guess(0, 0, Sound.CLACK));
        guesses.Add(new Guess(9, 0, Sound.CLACK));

        // Act
        var actual = theBurglarsDilemna.Solve(1, guesses);

        // Assert
        string expected = "5";
        Assert.AreEqual(expected, actual);
    }
}
