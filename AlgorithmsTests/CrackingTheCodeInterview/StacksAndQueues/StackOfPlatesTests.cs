using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CrackingTheCodeInterview.StacksAndQueues.StackOfPlates;

[TestClass]
public class StackOfPlatesTests
{

    [TestMethod]
    // We test with various capacities, to verify that the capacity has no impact on the results
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1, 11)]
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 2, 10)]
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 3, 9)]
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 4, 8)]
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 5, 7)]
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 6, 6)]
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 7, 5)]
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 8, 4)]
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 9, 3)]
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 10, 2)]
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 11, 1)]
    [DataRow(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, Int32.MinValue)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1, 11)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 2, 10)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 3, 9)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 4, 8)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 5, 7)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 6, 6)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 7, 5)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 8, 4)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 9, 3)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 10, 2)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 11, 1)]
    [DataRow(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, Int32.MinValue)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1, 11)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 2, 10)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 3, 9)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 4, 8)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 5, 7)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 6, 6)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 7, 5)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 8, 4)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 9, 3)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 10, 2)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 11, 1)]
    [DataRow(4, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, Int32.MinValue)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1, 11)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 2, 10)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 3, 9)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 4, 8)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 5, 7)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 6, 6)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 7, 5)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 8, 4)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 9, 3)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 10, 2)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 11, 1)]
    [DataRow(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, Int32.MinValue)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1, 11)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 2, 10)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 3, 9)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 4, 8)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 5, 7)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 6, 6)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 7, 5)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 8, 4)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 9, 3)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 10, 2)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 11, 1)]
    [DataRow(12, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, Int32.MinValue)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 1, 11)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 2, 10)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 3, 9)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 4, 8)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 5, 7)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 6, 6)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 7, 5)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 8, 4)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 9, 3)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 10, 2)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 11, 1)]
    [DataRow(20, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 12, Int32.MinValue)]
    public void Peek_PushesAndPops_PerformsCorrectly(int capacity, int[] inputs, int nbPops, int expected)
    {
        // Arrange
        StackOfPlates stackOfPlates = new(capacity);
        foreach (int n in inputs)
        {
            stackOfPlates.Push(n);
        }
        for (int i = 0; i < nbPops; i++)
        {
            stackOfPlates.Pop();
        }

        // Act
        int actual = stackOfPlates.Peek();

        // Assert
        actual.Should().Be(expected);
    }

}
