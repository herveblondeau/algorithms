using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ByTheme.Combinations
{
    [TestClass]
    public class CombinationsTests
    {

        [TestMethod]
        [DataRow(new int[] { 1 }, 1, 1)]
        [DataRow(new int[] { 1, 2 }, 1, 2)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, 10)]
        [DataRow(new int[] { 1, 2 }, 2, 1)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 4, 70)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 3, 120)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 5, 252)]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, 6, 924)]
        public void Check_WhenCalled_PerformsCorrectly(int[] values, int k, int expected)
        {
            // Arrange

            // Act
            var actual = Combinations.GetCombinations(values, k).Count();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
