using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Easy.Defibrillators;

[TestClass]
public class DefibrillatorsTests
{
    [TestMethod]
    [DynamicData(nameof(GetClosestDefibrillator_WhenCalled_PerformsCorrectly_Data), DynamicDataSourceType.Method)]
    public void GetClosestDefibrillator_WhenCalled_PerformsCorrectly(double longitude, double latitude, string[] defibrillatorDescriptions, string expected)
    {
        // Arrange
        Defibrillators defibrillators = new();

        // Act
        var result = defibrillators.GetClosestDefibrillator(longitude, latitude, defibrillatorDescriptions);

        // Assert
        result.Should().Be(expected);
    }

    public static IEnumerable<object[]> GetClosestDefibrillator_WhenCalled_PerformsCorrectly_Data()
    {
        // Codingame Example
        yield return new object[]
        {
            3.879483, 43.608177,
            new string[]
            {
                "1;Maison de la Prevention Sante;6 rue Maguelone 340000 Montpellier;;3,87952263361082;43,6071285339217",
                "2;Hotel de Ville;1 place Georges Freche 34267 Montpellier;;3,89652239197876;43,5987299452849",
                "3;Zoo de Lunaret;50 avenue Agropolis 34090 Mtp;;3,87388031141133;43,6395872778854",
            },
            "Maison de la Prevention Sante"
        };
    }
}
