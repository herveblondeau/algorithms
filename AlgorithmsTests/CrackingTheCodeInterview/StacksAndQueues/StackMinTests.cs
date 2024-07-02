using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.StacksAndQueues.StackMin;

[TestClass]
public class StackMinTests
{
    [TestMethod]
    [DataRow(new int[] { 1, 2, 3 }, 1)]
    [DataRow(new int[] { 3, 2, 1 }, 1)]
    [DataRow(new int[] { 2, 1, 3 }, 1)]
    public void Min_OnlyPushes_PerformsCorrectly(int[] inputs, int expected)
    {
        // Arrange
        StackMin stackMin = new();
        foreach (int n in inputs)
        {
            stackMin.Push(n);
        }

        // Act
        int actual = stackMin.Min();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(new int[] { 1, 2, 3 }, 1, 1)]
    [DataRow(new int[] { 3, 2, 1 }, 2, 3)]
    [DataRow(new int[] { 6, 3, 8, 3, 2, 2, 4 }, 1, 2)]
    [DataRow(new int[] { 6, 3, 8, 3, 2, 2, 4 }, 2, 2)]
    [DataRow(new int[] { 6, 3, 8, 3, 2, 2, 4 }, 3, 3)]
    [DataRow(new int[] { 6, 3, 8, 3, 2, 2, 4 }, 4, 3)]
    [DataRow(new int[] { 6, 3, 8, 3, 2, 2, 4 }, 5, 3)]
    [DataRow(new int[] { 6, 3, 8, 3, 2, 2, 4 }, 6, 6)]
    public void Min_PushesAndPops_PerformsCorrectly(int[] inputs, int nbPops, int expected)
    {
        // Arrange
        StackMin stackMin = new();
        foreach (int n in inputs)
        {
            stackMin.Push(n);
        }
        for (int i = 0; i < nbPops; i++)
        {
            stackMin.Pop();
        }

        // Act
        int actual = stackMin.Min();

        // Assert
        Assert.AreEqual(expected, actual);
    }

}
