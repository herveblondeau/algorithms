using Algorithms.CrackingTheCodeInterview;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests.CrackingTheCodeInterview
{
    [TestClass]
    public class OneAwayTests
    {
        [TestMethod]
        [DataRow("test")]
        [DataRow("my string")]
        [DataRow("another string")]
        public void AreOneAway_IdenticalStrings_ReturnsTrue(string input)
        {
            // Arrange

            // Act
            bool actual = OneAway.AreZeroOrOneAway(input, input);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("pale", "ple")]
        [DataRow("pales", "pale")]
        [DataRow("value", "values")]
        [DataRow("value", "vaslue")]
        [DataRow("value", "svalue")]
        [DataRow("values", "value")]
        [DataRow("vaslue", "value")]
        [DataRow("svalue", "value")]
        public void AreOneAway_OneAwayByLength_ReturnsTrue(string str1, string str2)
        {
            // Arrange

            // Act
            bool actual = OneAway.AreZeroOrOneAway(str1, str2);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("value", "valuess")]
        [DataRow("value", "vaslsue")]
        [DataRow("value", "svaluse")]
        [DataRow("value", "svasluse")]
        [DataRow("value", "svaslssuse")]
        [DataRow("valuess", "value")]
        [DataRow("vaslsue", "value")]
        [DataRow("svaluse", "value")]
        [DataRow("svasluse", "value")]
        [DataRow("svaslssuse", "value")]
        public void AreOneAway_MoreThanOneAwayByLength_ReturnsFalse(string str1, string str2)
        {
            // Arrange

            // Act
            bool actual = OneAway.AreZeroOrOneAway(str1, str2);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("pale", "bale")]
        [DataRow("value", "valus")]
        [DataRow("value", "vslue")]
        [DataRow("value", "valse")]
        [DataRow("valus", "value")]
        [DataRow("vslue", "value")]
        [DataRow("valse", "value")]
        public void AreOneAway_OneAwayByCharacterReplacement_ReturnsTrue(string str1, string str2)
        {
            // Arrange

            // Act
            bool actual = OneAway.AreZeroOrOneAway(str1, str2);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow("value", "vslus")]
        [DataRow("value", "vslse")]
        [DataRow("value", "valss")]
        [DataRow("vslus", "value")]
        [DataRow("vslse", "value")]
        [DataRow("valss", "value")]
        public void AreOneAway_MoreThanOneAwayByCharacterReplacement_ReturnsFalse(string str1, string str2)
        {
            // Arrange

            // Act
            bool actual = OneAway.AreZeroOrOneAway(str1, str2);

            // Assert
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow("test", "tset")]
        [DataRow("test", "etst")]
        [DataRow("my string", "ysgn irtm")]
        public void AreOneAway_ShuffledStrings_ReturnsFalse(string str1, string str2)
        {
            // Arrange

            // Act
            bool actual = OneAway.AreZeroOrOneAway(str1, str2);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
