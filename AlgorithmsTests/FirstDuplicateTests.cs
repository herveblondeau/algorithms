using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgorithmsTests
{
    [TestClass]
    public class FirstDuplicateTests
    {

        [TestMethod]
        [DataRow(new int[] { 1, 1, 2 }, 1)]
        [DataRow(new int[] { 1, 2, 3, 4, 2, 5, 6 }, 2)]
        [DataRow(new int[] { 8, 2, 3, 1, 2, 5, 6 }, 2)]
        [DataRow(new int[] { 1, 2, 3, 1, 2, 4, 5, 6 }, 1)]
        [DataRow(new int[] { 1, 2, 2, 3, 3, 4 }, 2)]
        public void Find_DuplicateInt_PerformsCorrectly(int[] elements, int expected)
        {
            // Arrange
            FirstDuplicate firstDuplicate = new FirstDuplicate();

            // Act
            var actual = firstDuplicate.Find(elements);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2 })]
        [DataRow(new int[] { 1, 2, 3, 4, 5, 6 })]
        [DataRow(new int[] { 182, 452, 263, 424, 385, 156 })]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Find_NoDuplicateInt_ThrowsException(int[] elements)
        {
            // Arrange
            FirstDuplicate firstDuplicate = new FirstDuplicate();

            // Act
            var actual = firstDuplicate.Find(elements);

            // Assert
        }
    }
}
