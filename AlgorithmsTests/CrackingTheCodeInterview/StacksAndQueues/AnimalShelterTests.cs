using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodeInterview.StacksAndQueues.AnimalShelter;

[TestClass]
public class AnimalShelterTests
{
    [TestMethod]
    [DataRow(1, 0)]
    [DataRow(2, 0)]
    [DataRow(5, 0)]
    [DataRow(1, 1)]
    [DataRow(2, 1)]
    [DataRow(5, 1)]
    [DataRow(1, 2)]
    [DataRow(2, 2)]
    [DataRow(5, 2)]
    [DataRow(1, 5)]
    [DataRow(2, 5)]
    [DataRow(5, 5)]
    public void DequeueDog_WhenCalled_PerformsCorrectly(int nbDogs, int nbCats)
    {
        // Arrange
        AnimalShelter animalShelter = new();
        int currentId = 1;
        for (int i = 0; i < nbDogs; i++)
        {
            animalShelter.Enqueue(new Dog
            {
                Id = currentId++
            });
        }
        for (int i = 0; i < nbCats; i++)
        {
            animalShelter.Enqueue(new Cat
            {
                Id = currentId++
            });
        }

        // Act
        int actualId = animalShelter.DequeueDog().Id;

        // Assert
        Assert.AreEqual(1, actualId);
    }

    [TestMethod]
    [DataRow(0, 1)]
    [DataRow(0, 2)]
    [DataRow(0, 5)]
    [DataRow(1, 1)]
    [DataRow(1, 2)]
    [DataRow(1, 5)]
    [DataRow(2, 1)]
    [DataRow(2, 2)]
    [DataRow(2, 5)]
    [DataRow(5, 1)]
    [DataRow(5, 2)]
    [DataRow(5, 5)]
    public void DequeueCat_WhenCalled_PerformsCorrectly(int nbDogs, int nbCats)
    {
        // Arrange
        AnimalShelter animalShelter = new();
        int currentId = 0;
        for (int i = 0; i < nbDogs; i++)
        {
            animalShelter.Enqueue(new Dog
            {
                Id = currentId++
            });
        }
        int expectedId = currentId;
        for (int i = 0; i < nbCats; i++)
        {
            animalShelter.Enqueue(new Cat
            {
                Id = currentId++
            });
        }

        // Act
        int actualId = animalShelter.DequeueCat().Id;

        // Assert
        Assert.AreEqual(expectedId, actualId);
    }

    [TestMethod]
    [DataRow(3, 1, 1)]
    [DataRow(2, 1, 2)]
    [DataRow(38, 1, 5)]
    [DataRow(0, 2, 1)]
    [DataRow(12, 2, 2)]
    [DataRow(7, 2, 5)]
    [DataRow(864, 5, 1)]
    [DataRow(2453, 5, 2)]
    [DataRow(-50, 5, 5)]
    public void DequeueAny_WhenCalled_PerformsCorrectly(int initialId, int nbDogs, int nbCats)
    {
        // Arrange
        AnimalShelter animalShelter = new();
        int currentId = initialId;
        for (int i = 0; i < nbDogs; i++)
        {
            animalShelter.Enqueue(new Dog
            {
                Id = currentId++
            });
        }
        for (int i = 0; i < nbCats; i++)
        {
            animalShelter.Enqueue(new Cat
            {
                Id = currentId++
            });
        }

        // Act
        int actualId = animalShelter.DequeueAny().Id;

        // Assert
        Assert.AreEqual(initialId, actualId);
    }

}
