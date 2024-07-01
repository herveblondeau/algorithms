using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Medium.ConwaySequence
{
    [TestClass]
    public class ConwaySequenceTests
    {
        [TestMethod]
        [DataRow(1, 6, new int[] { 3, 1, 2, 2, 1, 1 })]
        [DataRow(1, 11, new int[] { 1, 1, 1, 3, 1, 2, 2, 1, 1, 3, 3, 1, 1, 2, 1, 3, 2, 1, 1, 3, 2, 1, 2, 2, 2, 1 })]
        [DataRow(2, 1, new int[] { 2 })]
        [DataRow(5, 10, new int[] { 3, 1, 1, 3, 1, 1, 2, 2, 2, 1, 1, 3, 1, 1, 1, 2, 3, 1, 1, 3, 3, 2, 2, 1, 1, 5 })]
        public void GetNthLine_WhenCalled_PerformsCorrectly(int number, int n, int[] expected)
        {
            // Arrange
            ConwaySequence conwaySequence = new();

            // Act
            var actual = conwaySequence.GetNthLine(number, n);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
