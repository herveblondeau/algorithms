using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Bender
{
    [TestClass]
    public class BenderTests
    {
        [TestMethod]
        [DataRow(new string[] { "######", "#@E $#", "# N  #", "#X   #", "######" }, new string[] { "SOUTH", "EAST", "NORTH", "EAST", "EAST" }, "")]
        [DataRow(new string[] { "##########", "#        #", "#  S   W #", "#        #", "#  $     #", "#        #", "#@       #", "#        #", "#E     N #", "##########" }, new string[] { "SOUTH", "SOUTH", "EAST", "EAST", "EAST", "EAST", "EAST", "EAST", "NORTH", "NORTH", "NORTH", "NORTH", "NORTH", "NORTH", "WEST", "WEST", "WEST", "WEST", "SOUTH", "SOUTH" }, "")]
        public void Traverse_NoInfiniteLoop_ReturnsPath(string[] rows, string[] expectedPath, string dummy)
        {
            // Arrange
            Bender bender = new Bender();

            // Act
            var result = bender.Traverse(rows);

            // Assert
            Assert.IsFalse(result.IsStuckInInfiniteLoop);
            CollectionAssert.AreEqual(expectedPath, result.Path);
        }

        [TestMethod]
        [DataRow(new string[] { "###############", "#      IXXXXX #", "#  @          #", "#E S          #", "#             #", "#  I          #", "#  B          #", "#  B   S     W#", "#  B   T      #", "#             #", "#         T   #", "#         B   #", "#N          W$#", "#        XXXX #", "###############" })]
        public void Traverse_InfiniteLoop_ReturnsLoop(string[] rows)
        {
            // Arrange
            Bender bender = new Bender();

            // Act
            var result = bender.Traverse(rows);

            // Assert
            Assert.IsTrue(result.IsStuckInInfiniteLoop);
        }
    }
}
