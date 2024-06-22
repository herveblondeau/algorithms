using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeeksForGeeks.InversionOfArray
{
    [TestClass]
    public class InversionOfArrayTests
    {

        [TestMethod]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 2, 3, 4 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5 })]
        public void GetInversionCount_OrderedList_Returns0(int[] values)
        {
            // Arrange
            InversionOfArray inversionOfArraySolver = new();

            // Act
            var actual = inversionOfArraySolver.GetInversionCount(values);

            // Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 4, 1 }, 1)]
        [DataRow(new int[] { 2, 4, 1, 3, 5 }, 3)]
        [DataRow(new int[] { 8, 4, 2, 1 }, 6)]
        [DataRow(new int[] { 3, 1, 2 }, 2)]
        public void GetInversionCount_UnorderedList_PerformsCorrectly(int[] values, int expected)
        {
            // Arrange
            InversionOfArray inversionOfArraySolver = new();

            // Act
            var actual = inversionOfArraySolver.GetInversionCount(values);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
