using Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByTheme.LongestCommonSubSequence
{
    [TestClass]
    public class LongestCommonSubSequenceTests
    {
        [TestMethod]
        [DataRow("ABCDGH", "AEDFHR", "ADH")]
        [DataRow("AGGTAB", "GXTXAYB", "GTAB")]
        [DataRow("xyxyxzyDyxzyxyzKyxzyxyzLEOxyzyxyzMxzyzxyzyRJDHxzyxyzyxIOxzyxzyyxRyxyxyETxyyyxzyz", "DKbcbacLEbcacbaOMcbacbRcJcccbDacbabcHIORbcbcabcEacbcaT", "DKLEOMRJDHIORET")]
        public void Memoization_WhenCalled_PerformsCorrectly(string string1, string string2, string expected)
        {
            // Arrange
            LongestCommonSubSequence longestCommonSubSequenceSolver = new LongestCommonSubSequence();

            // Act
            var actual = longestCommonSubSequenceSolver.Memoization(string1, string2);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("ABCDGH", "AEDFHR", "ADH")]
        [DataRow("AGGTAB", "GXTXAYB", "GTAB")]
        public void Recursion_WhenCalled_PerformsCorrectly(string string1, string string2, string expected)
        {
            // Arrange
            LongestCommonSubSequence longestCommonSubSequenceSolver = new LongestCommonSubSequence();

            // Act
            var actual = longestCommonSubSequenceSolver.Recursion(string1, string2);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
