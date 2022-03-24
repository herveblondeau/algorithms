using Codingame.Staircases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codingame.TwoEggProblem
{
    [TestClass]
    public class TwoEggProblemTests
    {

        [TestMethod]
        [DataRow(100, 14)]
        public void GetMinimumDrops_WhenCalled_PerformsCorrectly(int floors, int expected)
        {
            // Arrange
            TwoEggProblem twoEggProblem = new TwoEggProblem();

            // Act
            var actual = twoEggProblem.GetMinimumDrops(floors);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
