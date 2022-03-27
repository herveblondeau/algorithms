using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.TimerForClashOfCode
{
    [TestClass]
    public class TimerForClashOfCodeTests
    {

        [TestMethod]
        [DataRow(new int[] { 13 }, 31)]
        [DataRow(new int[] { 65, 72 }, 100)]
        [DataRow(new int[] { 28, 130, 190, 249 }, 19)]
        [DataRow(new int[] { 156 }, 0)]
        [DataRow(new int[] { 24, 165, 229, 281 }, 0)]
        public void GetStartTime_WhenCalled_PerformsCorrectly(int[] arrivalTimes, int expected)
        {
            // Arrange
            TimerForClashOfCode timerForClashOfCode = new TimerForClashOfCode();

            // Act
            var actual = timerForClashOfCode.GetStartTime(arrivalTimes);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
