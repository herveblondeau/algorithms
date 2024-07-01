using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.OrderOfOopserations
{
    [TestClass]
    public class OrderOfOopserationsTests
    {

        [TestMethod]
        [DataRow("1+2", 3)]
        [DataRow("3*2+5", 21)]
        [DataRow("42", 42)]
        [DataRow("3*-4/2", -6)]
        [DataRow("-3", -3)]
        [DataRow("-3+5", 2)]
        [DataRow("540-6+5-40*6+87+9*3*62+1+10-3620/-44+54+-9*8-4", -2123007192)]
        [DataRow("2*3-18/1+5/3-1*2", 4)]
        [DataRow("5*2+3+4+5+6-7-8-9-10+11+12+13+14+15-16-20-28+35+555-487", -6100)]
        public void ComputeExpression_Miscellaneous_PerformsCorrectly(string input, int expected)
        {
            // Arrange
            OrderOfOopserations OrderOfOopserations = new();

            // Act
            var actual = OrderOfOopserations.ComputeExpression(input);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
