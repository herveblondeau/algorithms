using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class LongestCommonSubSequenceTests
    {
        [TestMethod]
        [DataRow("ABCDGH", "AEDFHR", "ADH")]
        [DataRow("AGGTAB", "GXTXAYB", "GTAB")]
        public void FindLongestCommonSubSequence_WhenCalled_PerformsCorrectly(string string1, string string2, string expected)
        {
            // Arrange
            LongestCommonSubSequence longestCommonSubSequenceSolver = new LongestCommonSubSequence();

            // Act
            var actual = longestCommonSubSequenceSolver.FindLongestCommonSubSequence(string1, string2);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
