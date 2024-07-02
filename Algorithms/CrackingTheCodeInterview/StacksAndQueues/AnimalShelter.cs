using System;
using System.Collections.Generic;

namespace CrackingTheCodeInterview.StacksAndQueues.AnimalShelter;

// Source: "Cracking the coding interview" book (3.6 - Animal shelter)
public class AnimalShelter
{
    // We use integers instead of a generic type as the focus of the problem is not on genericity

    private Queue<Dog> _dogs;
    private Queue<Cat> _cats;

    public AnimalShelter()
    {
        _dogs = new Queue<Dog>();
        _cats = new Queue<Cat>();
    }

    public void Enqueue(Dog dog)
    {
        dog.ArrivalDate = DateTime.Now;
        _dogs.Enqueue(dog);
    }

    public void Enqueue(Cat cat)
    {
        cat.ArrivalDate = DateTime.Now;
        _cats.Enqueue(cat);
    }

    public Animal DequeueAny()
    {
        Animal oldestDog = _dogs.Peek();
        Animal oldestCat = _cats.Peek();

        if (oldestDog is null) return oldestCat;
        if (oldestCat is null) return oldestDog;

        return (oldestDog.ArrivalDate < oldestCat.ArrivalDate) ? (Animal)_dogs.Dequeue() : _cats.Dequeue();
    }

    public Dog DequeueDog()
    {
        return _dogs.Dequeue();
    }

    public Cat DequeueCat()
    {
        return _cats.Dequeue();
    }

}

public class Animal
{
    public int Id { get; set; }
    public DateTime ArrivalDate { get; set; }
}

public class Dog : Animal
{

}

public class Cat : Animal
{

}
