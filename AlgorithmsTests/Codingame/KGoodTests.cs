using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.KGood
{
    [TestClass]
    public class KGoodTests
    {
        [TestMethod]
        [DataRow("aaaaabcdef", 3, 7)]
        [DataRow("aabacdef", 5, 7)]
        [DataRow("aaaaabcdef", 26, 10)]
        public void GetLongestLength_WhenCalled_PerformsCorrectly(string input, int k, int expected)
        {
            // Arrange
            KGood kGood = new KGood();

            // Act
            var actual = kGood.GetLongestKSubstringLength(input, k);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
