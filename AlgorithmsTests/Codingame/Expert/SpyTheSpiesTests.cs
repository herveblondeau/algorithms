using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Expert.SpyTheSpies;

[TestClass]
public class SpyTheSpiesTests
{

    [TestMethod]
    public void FindShortestPath_Example1_PerformsCorrectly()
    {
        // Arrange
        SpyTheSpies spyTheSpies = new();
        Dictionary<string, HashSet<string>> suspects = new()
        {
            { "Tonya", ["french", "blue-eyes"] },
            { "Ned", ["english", "blue-eyes"] },
            { "Cindy", ["tall"] },
        };
        HashSet<string> spies = ["Ned"];

        // Act
        var actual = spyTheSpies.FindShortestPath(suspects, spies);

        // Assert
        actual.Should().BeEquivalentTo([("english", false)]);
    }

    [TestMethod]
    public void FindShortestPath_Example2_PerformsCorrectly()
    {
        // Arrange
        SpyTheSpies spyTheSpies = new();
        Dictionary<string, HashSet<string>> suspects = new()
        {
            { "Rick", ["brown-hair", "glasses", "tall"] },
            { "Marcia", ["thin", "freckled"] },
            { "Jasmin", ["chinese", "short", "thin", "brown-hair"] },
            { "Matt", ["german", "freckled"] },
            { "Sam", ["thin", "glasses", "muscular"] },
            { "Rose", ["german", "tall", "thin"] },
        };
        HashSet<string> spies = ["Jasmin", "Sam", "Rose"];

        // Act
        var actual = spyTheSpies.FindShortestPath(suspects, spies);

        // Assert
        actual.Should().BeEquivalentTo([("freckled", true), ("thin", false)]);
    }

    [TestMethod]
    public void FindShortestPath_ExtraSteps_PerformsCorrectly()
    {
        // Arrange
        SpyTheSpies spyTheSpies = new();
        Dictionary<string, HashSet<string>> suspects = new()
        {
            { "Madison", ["tall", "french", "brown-eyed"] },
            { "Albert", ["tall", "tattooed"] },
            { "Alethea", ["tall", "french", "tattooed"] },
            { "Salazar", ["tattooed", "green-eyed"] },
            { "Aline", ["czech", "thin", "black-haired"] },
            { "Campion", ["tattooed", "tall"] },
            { "Evangeline", ["tattooed"]},
            { "Brian", ["thin", "tattooed green-eyed"] },
            { "Hollis", ["black-haired", "tall"] },
            { "Oberon", ["black-haired"] },
            { "Elenora", ["tattooed", "french"] },
            { "Tavian", ["french", "brown-eyed", "black-haired"] },
            { "Bracken", ["black-haired", "thin"] },
            { "Alton", ["tattooed", "green-eyed", "italian", "black-haired"] },
            { "Natalie", ["thin", "czech"] },
        };
        HashSet<string> spies = ["Albert", "Elenora", "Alton", "Alethea", "Campion", "Evangeline"];

        // Act
        var actual = spyTheSpies.FindShortestPath(suspects, spies);

        // Assert
        actual.Should().BeEquivalentTo([("italian", false), ("green-eyed", true), ("tattooed", false)]);
    }

    [TestMethod]
    public void FindShortestPath_CommonDifferentiator_PerformsCorrectly()
    {
        // Arrange
        SpyTheSpies spyTheSpies = new();
        Dictionary<string, HashSet<string>> suspects = new()
        {
            { "Tabitha", ["scottish"] },
            { "Rolf", ["hebrew"] },
            { "Mohammad", ["arabic"] },
            { "Jacob", ["arabic"] },
            { "Derick", ["hebrew"] },
            { "Meta", ["arabic"] },
            { "Ronaldo", ["scottish"] },
            { "Melville", ["arabic"] },
            { "Hermon", ["arabic"] },
            { "Tempest", ["swedish"] },
            { "Jeanne", ["persian"] },
            { "Kourtney", ["arabic"] },
            { "Dallas", ["arabic"] },
            { "Vena", ["arabic"] },
            { "Eros", ["arabic"] },
        };
        HashSet<string> spies = ["Derick", "Ronaldo", "Tempest", "Rolf", "Jeanne", "Tabitha"];

        // Act
        var actual = spyTheSpies.FindShortestPath(suspects, spies);

        // Assert
        actual.Should().BeEquivalentTo([("arabic", true)]);
    }

    [TestMethod]
    public void FindShortestPath_VeryEntangled_PerformsCorrectly()
    {
        // Arrange
        SpyTheSpies spyTheSpies = new();
        Dictionary<string, HashSet<string>> suspects = new()
        {
            { "Vlad", ["russian", "blond"] },
            { "Norris", ["chubby", "red-haired"] },
            { "Sophie", ["short", "chubby"] },
            { "Rufus", ["french", "freckled"] },
            { "Destiny", ["brown-haired"] },
            { "Marcus", ["tall", "french"] },
            { "Ridley", ["blue-eyed"] },
            { "Hans", ["red-haired", "russian"] },
            { "Barbie", ["gray-eyed"] },
            { "Nick", ["thai", "thin"] },
            { "Kathy", ["freckled", "thai"] },
            { "Theresa", ["gray-haired"] },
            { "Xander", ["brown-eyed"] },
            { "Velma", ["blond", "tall"] },
            { "Mandy", ["thin", "gray-eyed"] },
        };
        HashSet<string> spies = ["Sophie", "Hans", "Velma", "Nick", "Rufus", "Barbie"];

        // Act
        var actual = spyTheSpies.FindShortestPath(suspects, spies);

        // Assert
        actual.Should().BeEquivalentTo(
        [
            ("short", false),
            ("chubby", true),
            ("red-haired", false),
            ("russian", true),
            ("blond", false),
            ("tall", true),
            ("french", false),
            ("freckled", true),
            ("thai", false),
            ("thin", true),
            ("gray-eyed", false),
        ]);
    }
}
