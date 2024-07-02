using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByTheme.IsPangram;

[TestClass]
public class IsPangramTests
{

    [TestMethod]
    [DataRow("alkgfkljgflkj", false)]
    [DataRow("abcdefghijklmnopqrstuvwxy", false)]
    [DataRow("abcdefghijklmnopqrstuvwxyz", true)]
    [DataRow("abcdefGhijklmnoPQRstuVWxyz", true)]
    [DataRow("abcde fghijk lmno pqrs   tuvw xyz", true)]
    [DataRow("abc54908de fghijk lm43no pq%./?�rs   tuvw xyz", true)]
    [DataRow("bcdenopfg hijaklmqruvw stxyz", true)]
    [DataRow("The quick brown fox jumps over the lazy dog", true)]
    public void Check_WhenCalled_PerformsCorrectly(string text, bool expected)
    {
        // Arrange
        IsPangram isPangram = new();

        // Act
        var actual = isPangram.Check(text);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
