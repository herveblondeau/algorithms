using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Hard.SimpleSafecracking;

[TestClass]
public class SimpleSafecrackingTests
{
    [TestMethod]
    [DataRow("Aol zhml jvtipuhapvu pz: zpe-mvby-zpe-mvby-aoyll", 64643)]
    [DataRow("Wkh vdih frpelqdwlrq lv: wkuhh-ilyh-rqh-vla-wzr", 35162)]
    [DataRow("Dro ckpo mywlsxkdsyx sc: pyeb-xsxo-yxo-osqrd-dgy-joby-dgy-yxo-csh-drboo", 4918202163)]
    [DataRow("Ymj xfkj htrgnsfynts nx: ktzw-ejwt-ejwt-ktzw-ktzw-ejwt-jnlmy-xjajs-xjajs", 400440877)]
    public void GetNthLine_WhenCalled_PerformsCorrectly(string encoded, long expected)
    {
        // Arrange
        SimpleSafecracking simpleSafecracking = new();

        // Act
        var actual = simpleSafecracking.Decode(encoded);

        // Assert
        actual.Should().Be(expected);
    }
}
