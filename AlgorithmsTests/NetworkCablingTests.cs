using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgorithmsTests
{
    [TestClass]
    public class NetworkCablingTests
    {
        [TestMethod]
        [DataRow(new long[] { 0, 1, 2 }, new long[] { 0, 1, 2 }, 4)]
        [DataRow(new long[] { 1, 0, 2 }, new long[] { 2, 0, 2 }, 4)]
        [DataRow(new long[] { 1, 0, 2, 1 }, new long[] { 2, 0, 2, 3 }, 5)]
        [DataRow(new long[] { 1 }, new long[] { 1 }, 0)]
        [DataRow(new long[] { -5, -9, 3 }, new long[] { -3, 2, -4 }, 18)]
        [DataRow(new long[] { -28189131, 102460950, 938059973, -334087877, 842560881, -416604701, 19715507, 846505116 }, new long[] { 593661218, 1038903636, -816049599, -290840615, -116496866, 690825290, 470868309, -694479954 }, 6066790161)]
        [DataRow(new long[] { -162526110, -4895917, 141008358, 206758372, 88473194, 202531345, -135195154, 171101176, -266264470, -205060869, -137959173 }, new long[] { -252675912, -240420085, -106615672, -63665546, -37289256, 73399429, 157092065, 161166515, 191334680, 233111863, 262220087 }, 2178614523)]
        public void GetMinimumCableLength_WhenCalled_PerformsCorrectly(long[] xPositions, long[] yPositions, long expected)
        {
            // Arrange
            NetworkCabling networkCabling = new NetworkCabling();

            // Act
            var actual = networkCabling.GetMinimumCableLength(xPositions, yPositions);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
