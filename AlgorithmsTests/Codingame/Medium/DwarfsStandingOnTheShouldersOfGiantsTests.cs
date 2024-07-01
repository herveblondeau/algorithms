using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Codingame.DwarfsStandingOnTheShouldersOfGiants
{
    [TestClass]
    public class DwarfsStandingOnTheShouldersOfGiantsTests
    {

        [TestMethod]
        public void GetLongestInfluenceChain_SimpleExample_PerformsCorrectly()
        {
            // Arrange
            Dictionary<int, List<int>> relations = new()
            {
                { 1, [2, 3] },
                { 3, [4] }
            };
            DwarfsStandingOnTheShouldersOfGiants dwarfsStandingOnTheShouldersOfGiants = new();

            // Act
            var actual = dwarfsStandingOnTheShouldersOfGiants.GetLongestInfluence(relations);

            // Assert
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void GetLongestInfluenceChain_CompleteExample_PerformsCorrectly()
        {
            // Arrange
            Dictionary<int, List<int>> relations = new()
            {
                { 1, [2, 3] },
                { 2, [4, 5] },
                { 3, [4] },
                { 10, [1, 3, 11] }
            };
            DwarfsStandingOnTheShouldersOfGiants dwarfsStandingOnTheShouldersOfGiants = new();

            // Act
            var actual = dwarfsStandingOnTheShouldersOfGiants.GetLongestInfluence(relations);

            // Assert
            Assert.AreEqual(4, actual);
        }

        [TestMethod]
        public void GetLongestInfluenceChain_SeveralMentors_PerformsCorrectly()
        {
            // Arrange
            Dictionary<int, List<int>> relations = new()
            {
                { 1, [2] },
                { 2, [3] },
                { 6, [4] },
                { 8, [9] }
            };
            DwarfsStandingOnTheShouldersOfGiants dwarfsStandingOnTheShouldersOfGiants = new();

            // Act
            var actual = dwarfsStandingOnTheShouldersOfGiants.GetLongestInfluence(relations);

            // Assert
            Assert.AreEqual(3, actual);
        }
    }
}
