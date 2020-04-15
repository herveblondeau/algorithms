using Codingame.DwarfsStandingOnTheShouldersOfGiants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgorithmsTests
{
    [TestClass]
    public class DwarfsStandingOnTheShouldersOfGiantsTests
    {

        [TestMethod]
        public void GetLongestInfluenceChain_SimpleExample_PerformsCorrectly()
        {
            // Arrange
            Dictionary<int, List<int>> relations = new Dictionary<int, List<int>>();
            relations.Add(1, new List<int> { 2, 3 });
            relations.Add(3, new List<int> { 4 });
            DwarfsStandingOnTheShouldersOfGiants dwarfsStandingOnTheShouldersOfGiants = new DwarfsStandingOnTheShouldersOfGiants();

            // Act
            var actual = dwarfsStandingOnTheShouldersOfGiants.GetLongestInfluence(relations);

            // Assert
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void GetLongestInfluenceChain_CompleteExample_PerformsCorrectly()
        {
            // Arrange
            Dictionary<int, List<int>> relations = new Dictionary<int, List<int>>();
            relations.Add(1, new List<int> { 2, 3 });
            relations.Add(2, new List<int> { 4, 5 });
            relations.Add(3, new List<int> { 4 });
            relations.Add(10, new List<int> { 1, 3, 11 });
            DwarfsStandingOnTheShouldersOfGiants dwarfsStandingOnTheShouldersOfGiants = new DwarfsStandingOnTheShouldersOfGiants();

            // Act
            var actual = dwarfsStandingOnTheShouldersOfGiants.GetLongestInfluence(relations);

            // Assert
            Assert.AreEqual(4, actual);
        }

        [TestMethod]
        public void GetLongestInfluenceChain_SeveralMentors_PerformsCorrectly()
        {
            // Arrange
            Dictionary<int, List<int>> relations = new Dictionary<int, List<int>>();
            relations.Add(1, new List<int> { 2 });
            relations.Add(2, new List<int> { 3 });
            relations.Add(6, new List<int> { 4 });
            relations.Add(8, new List<int> { 9 });
            DwarfsStandingOnTheShouldersOfGiants dwarfsStandingOnTheShouldersOfGiants = new DwarfsStandingOnTheShouldersOfGiants();

            // Act
            var actual = dwarfsStandingOnTheShouldersOfGiants.GetLongestInfluence(relations);

            // Assert
            Assert.AreEqual(3, actual);
        }
    }
}
