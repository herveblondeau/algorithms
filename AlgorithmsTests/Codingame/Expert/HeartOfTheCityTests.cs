using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.HeartOfTheCity;

[TestClass]
public class HeartOfTheCityTests
{

    [TestMethod]
    [DataRow(3, 8)]
    [DataRow(7, 32)]
    [DataRow(11, 80)]
    [DataRow(33, 640)]
    [DataRow(999999, 607926717408)]
    [DataRow(931547, 527547299504)]
    [DataRow(9999999, 60792708184960)]
    public void GetNumberOfVisibleBuildings_WhenCalled_PerformsCorrectly(long citySize, long expected)
    {
        // Arrange
        HeartOfTheCity HeartOfTheCity = new();

        // Act
        var actual = HeartOfTheCity.GetNumberOfVisibleBuildings(citySize);

        // Assert
        actual.Should().Be(expected);
    }
}
