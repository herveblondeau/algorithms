using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.AdventOfCode._2024;

[TestClass]
public class Day11PlutonianPebblesTests
{

    #region Part 1

    [TestMethod]
    public void CalculateSumOfScores_SampleStones_PerformsCorrectly()
    {
        // Arrange
        Day11PlutonianPebbles day11PlutonianPebbles = new();
        var stones = _getSampleStones();

        // Act
        var actual = day11PlutonianPebbles.CalculateNumberOfStonesWithRegularLoop(stones, 25);

        // Assert
        actual.Should().Be(55312);
    }

    [TestMethod]
    public void CalculateSumOfScores_TestStones_PerformsCorrectly()
    {
        // Arrange
        Day11PlutonianPebbles day11PlutonianPebbles = new();
        var stones = _getTestStones();

        // Act
        var actual = day11PlutonianPebbles.CalculateNumberOfStonesWithRegularLoop(stones, 25);

        // Assert
        actual.Should().Be(186175);
    }

    #endregion

    private List<long> _getSampleStones()
    {
        return [125, 17];
    }

    private List<long> _getTestStones()
    {
        return [5688, 62084, 2, 3248809, 179, 79, 0, 172169];
    }
}
