using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode.SortColors
{
    [TestClass]
    public class SortColorsTests
    {
        [TestMethod]
        [DataRow(new int[] { 0 })]
        [DataRow(new int[] { 0, 0 })]
        [DataRow(new int[] { 0, 0, 0 })]
        [DataRow(new int[] { 0, 0, 0, 0, 0 })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 1 })]
        [DataRow(new int[] { 1, 1, 1 })]
        [DataRow(new int[] { 1, 1, 1, 1, 1 })]
        [DataRow(new int[] { 2 })]
        [DataRow(new int[] { 2, 2 })]
        [DataRow(new int[] { 2, 2, 2 })]
        [DataRow(new int[] { 2, 2, 2, 2, 2 })]
        public void Sort_OneColor_PerformsCorrectly(int[] values)
        {
            // Arrange

            // Act
            int[] actual = SortColors.Sort(values);

            // Assert
            CollectionAssert.AreEqual(values, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 0, 1 }, new int[] { 0, 1 })]
        [DataRow(new int[] { 1, 0 }, new int[] { 0, 1 })]
        [DataRow(new int[] { 2, 1 }, new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 0, 1 }, new int[] { 0, 1, 1 })]
        [DataRow(new int[] { 2, 2, 1, 1, 2 }, new int[] { 1, 1, 2, 2, 2 })]
        [DataRow(new int[] { 1, 0, 0, 0, 1, 0 }, new int[] { 0, 0, 0, 0, 1, 1 })]
        [DataRow(new int[] { 0, 0, 0, 2, 2, 1, 0, 0, 0, 1, 0, 2, 2 }, new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 2, 2, 2 })]
        public void Sort_TwoColors_PerformsCorrectly(int[] values, int[] expected)
        {
            // Arrange

            // Act
            int[] actual = SortColors.Sort(values);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
