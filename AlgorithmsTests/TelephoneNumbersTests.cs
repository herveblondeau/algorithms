using Microsoft.VisualStudio.TestTools.UnitTesting;
using TelephoneNumbers;

namespace AlgorithmsTests
{
    [TestClass]
    public class TelephoneNumbersTests
    {
        [TestMethod]
        [DataRow(new string[] { "0467123456" }, 10)]
        [DataRow(new string[] { "0123456789", "1123456789" }, 20)]
        [DataRow(new string[] { "0123456789", "0123" }, 10)]
        [DataRow(new string[] { "0412578440", "0412199803", "0468892011", "112", "15" }, 28)]
        public void FindBestWord_WhenCalled_PerformsCorrectly(string[] phoneNumbers, int expected)
        {
            // Arrange
            TelephoneNumbersSolver telephoneNumbersSolver = new TelephoneNumbersSolver();

            // Act
            var actual = telephoneNumbersSolver.GetNumberOfRequiredNodes(phoneNumbers);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
