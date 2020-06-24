using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LeetCode.FindAllDuplicates
{
    [TestClass]
    public class ArrayDuplicatesTests
    {
        [TestMethod]
        [DataRow(new int[] { })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { 1, 2 })]
        [DataRow(new int[] { 4, 3, 5, 1, 2 })]
        [DataRow(new int[] { 6, 8, 2, 3, 1, 5, 4, 7 })]
        public void FindAllDuplicates_NoDuplicate_ReturnsEmptyArray(int[] values)
        {
            // Arrange

            // Act
            int[] actual = ArrayDuplicates.FindAllDuplicates(values);

            // Assert
            Assert.AreEqual(0, actual.Length);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 1 }, new int[] { 1 })]
        [DataRow(new int[] { 1, 2, 1 }, new int[] { 1 })]
        [DataRow(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new int[] { 2, 3 })]
        public void FindAllDuplicates_Duplicates_ReturnsDuplicates(int[] values, int[] expected)
        {
            // Arrange

            // Act
            int[] actual = ArrayDuplicates.FindAllDuplicates(values);

            // Assert
            Array.Sort(expected);
            Array.Sort(actual);
            Assert.AreEqual(expected.Length, actual.Length);
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
