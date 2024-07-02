using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ByTheme.Duplicates;

[TestClass]
public class DuplicatesTests
{

    [TestMethod]
    [DataRow(new int[] { 1, 1, 2 }, 1)]
    [DataRow(new int[] { 1, 2, 3, 4, 2, 5, 6 }, 2)]
    [DataRow(new int[] { 8, 2, 3, 1, 2, 5, 6 }, 2)]
    [DataRow(new int[] { 1, 2, 3, 1, 2, 4, 5, 6 }, 1)]
    [DataRow(new int[] { 1, 2, 2, 3, 3, 4 }, 2)]
    public void FindFirstDuplicate_DuplicateInt_PerformsCorrectly(int[] elements, int expected)
    {
        // Arrange
        Duplicates duplicates = new();

        // Act
        var actual = duplicates.FindFirstDuplicate(elements);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(new int[] { 1, 2 })]
    [DataRow(new int[] { 1, 2, 3, 4, 5, 6 })]
    [DataRow(new int[] { 182, 452, 263, 424, 385, 156 })]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void FindFirstDuplicate_NoDuplicateInt_ThrowsException(int[] elements)
    {
        // Arrange
        Duplicates firstDuplicate = new();

        // Act
        var actual = firstDuplicate.FindFirstDuplicate(elements);
    }

    [TestMethod]
    [DataRow(new int[] { 1, 1, 2 }, 2)]
    [DataRow(new int[] { 1, 2, 2 }, 1)]
    [DataRow(new int[] { 6, 3, 2, 3, 6 }, 2)]
    [DataRow(new int[] { 8, 8, 2, 2, 5, 4, 4, 3, 7, 7, 7 }, 5)]
    [DataRow(new int[] { 8, 7, 2, 5, 4, 2, 4, 3, 8, 7, 7 }, 5)]
    [DataRow(new int[] { 1, 1, 1, 2, 3, 3, 3, 4, 5, 5, 5, 6 }, 2)]
    [DataRow(new int[] { 1, 2, 3, 2, 1, 4 }, 3)]
    public void FindFirstNonDuplicate_NonDuplicateInt_PerformsCorrectly(int[] elements, int expected)
    {
        // Arrange
        Duplicates duplicates = new();

        // Act
        var actual = duplicates.FindFirstNonDuplicate(elements);

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(new int[] { 1, 1 })]
    [DataRow(new int[] { 1, 1, 2, 2 })]
    [DataRow(new int[] { 1, 2, 3, 1, 2, 3, 1, 2, 3})]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void FindFirstNonDuplicate_NoNonDuplicateInt_ThrowsException(int[] elements)
    {
        // Arrange
        Duplicates duplicates = new();

        // Act
        var actual = duplicates.FindFirstNonDuplicate(elements);
    }
}
