using BenderRobot;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsTests
{
    [TestClass]
    public class BenderTests
    {
        [TestMethod]
        [DataRow(new string[] { "######", "#@E $#", "# N  #", "#X   #", "######" }, new string[] { "SOUTH", "EAST", "NORTH", "EAST", "EAST" }, "")]
        [DataRow(new string[] { "##########", "#        #", "#  S   W #", "#        #", "#  $     #", "#        #", "#@       #", "#        #", "#E     N #", "##########" }, new string[] { "SOUTH", "SOUTH", "EAST", "EAST", "EAST", "EAST", "EAST", "EAST", "NORTH", "NORTH", "NORTH", "NORTH", "NORTH", "NORTH", "WEST", "WEST", "WEST", "WEST", "SOUTH", "SOUTH" }, "")]
        //[DataRow(new string[] { "########", "# @    #", "#     X#", "# XXX  #", "#   XX #", "#   XX #", "#     $#", "########" }, new string[] {  }, "")]
        public void Traverse_NoInfiniteLoop_PerformsCorrectly(string[] rows, string[] expectedPath, string dummy)
        {
            // Arrange
            Bender bender = new Bender();

            // Act
            var isStuckInInfiniteLoop = bender.IsStuckInInfiniteLoop();
            var actualPath = bender.Traverse(rows);

            // Assert
            Assert.IsFalse(isStuckInInfiniteLoop);
            CollectionAssert.AreEqual(expectedPath, actualPath);
        }
    }
}
