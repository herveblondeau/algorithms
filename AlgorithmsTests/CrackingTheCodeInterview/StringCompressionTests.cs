using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.StringCompression
{
    [TestClass]
    public class StringCompressionTests
    {
        [TestMethod]
        [DataRow("aaaaa", "a5")]
        [DataRow("aaaaabbbaa", "a5b3a2")]
        [DataRow("aaaaaaaaaaaaaaabbbbbbbbbccccccccccdddd", "a15b9c10d4")]
        public void Compress_CompressedStringShorterThanOriginal_ReturnsCompressedString(string input, string expected)
        {
            // Arrange

            // Act
            string actual = StringCompression.Compress(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("abb")]
        public void Compress_CompressedStringSameLengthAsOriginal_ReturnsOriginalString(string input)
        {
            // Arrange

            // Act
            string actual = StringCompression.Compress(input);

            // Assert
            Assert.AreEqual(input, actual);
        }

        [TestMethod]
        [DataRow("a")]
        [DataRow("ab")]
        [DataRow("abc")]
        [DataRow("abcd")]
        [DataRow("aabbc")]
        public void Compress_CompressedStringLongerThanOriginal_ReturnsOriginalString(string input)
        {
            // Arrange

            // Act
            string actual = StringCompression.Compress(input);

            // Assert
            Assert.AreEqual(input, actual);
        }
    }
}
