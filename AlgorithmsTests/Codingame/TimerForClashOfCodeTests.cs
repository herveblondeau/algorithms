using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.TimerForClashOfCode
{
    [TestClass]
    public class TimerForClashOfCodeTests
    {

        [TestMethod]
        [DataRow(new int[] { 287 }, 31)]
        [DataRow(new int[] { 235, 228 }, 100)]
        [DataRow(new int[] { 272, 170, 110, 51 }, 19)]
        [DataRow(new int[] { 134 }, 0)]
        [DataRow(new int[] { 276, 135, 71, 19 }, 0)]
        [DataRow(new int[] { 250, 209, 164, 140, 116, 107, 103 }, 103)] // room filled
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
