// https://www.codingame.com/training/expert/the-two-piles-difference

using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame.TheTwoPilesDifference;

public class TheTwoPilesDifference
{
    private Random _random = null!;

    public int FindMinDifference(int[] values)
    {
        /**
         * This is implemented using a genetic algorithm
         *
         * Note: other algorithms have been explored but could not fully solve the problem
         * - from a starting configuration, try the first swap that leads to a lower difference, then make that the new configuration. Repeat this process until there is no swap that reduces the difference => leads to being stuck to a local optimum depending on the starting configuration and the order the swaps are tried
         * - calculate the difference of all possible combinations => solves the local optimum problem, but is horribly slow with a large number of values (the complexity is O(C(n, n/2)), which is between O(2^n) and O(n!))
         */

        // These parameters pass all Codingame tests. They would need to be finetuned with different constraints
        var populationSize = 200;
        int nbGenerations = 1000;
        int nbMutationsPerGeneration = 100;

        _random = new Random();

        // Selection: generate a population of random two piles configurations
        var population = new List<TwoPiles>();
        for (int i = 0; i < populationSize; i++)
        {
            population.Add(_generateRandomTwoPiles(values));
        }

        // Generation loop
        for (int i = 0; i < nbGenerations; i++)
        {
            // Mutation: select a random subset of the population and mutate each selected individual to add that many offsprings to the population
            var subPopulation = population.OrderBy(x => _random.Next()).Take(nbMutationsPerGeneration);
            foreach (var individual in subPopulation)
            {
                population.Add(individual.Mutate());
            }

            // Recombination: keep the fittest individuals (lowest difference configurations) to keep the population size constant
            population = population
                .OrderBy(p => p.Difference) // the fittest elements are the ones with the lowest difference
                .Take(populationSize)
                .ToList();
        }

        return population.First().Difference;
    }

    private TwoPiles _generateRandomTwoPiles(int[] values)
    {
        var nbValues = values.Length;

        int[] shuffledValues = new int[nbValues];
        for (int i = 0; i < nbValues; i++)
        {
            shuffledValues[i] = values[i];
        }

        return new TwoPiles(shuffledValues.OrderBy(item => _random.Next()).ToArray());
    }

    // Represents a configuration of two piles
    private class TwoPiles
    {
        // Only one array is used to represent both piles:
        // - the first half are the elements to "sum-square"
        // - the second half are the elements to multiply
        public int[] Values { get; private set; }
        public int Difference { get; private set; }

        private Random _random;

        public TwoPiles(int[] values)
        {
            if (values.Length % 2 != 0)
            {
                throw new ArgumentException("There must be an even number of values");
            }

            Values = values;

            Difference = _computeDifference();

            _random = new Random();
        }

        private int _computeDifference()
        {
            var nbValues = Values.Length;

            int sum = 0;
            for (int i = 0; i < nbValues / 2; i++) sum += Values[i];

            int product = 1;
            for (int i = nbValues / 2; i < nbValues; i++) product *= Values[i];

            return Math.Abs(sum * sum - product);
        }

        // Generate a random mutation
        public TwoPiles Mutate()
        {
            var nbValues = Values.Length;
            int[] swappedValues = new int[nbValues];
            for (int i = 0; i < nbValues; i++)
            {
                swappedValues[i] = Values[i];
            }

            int sumSquareIndex = _random.Next(0, nbValues / 2);
            int multiplyIndex = _random.Next(nbValues / 2, nbValues);
            (swappedValues[sumSquareIndex], swappedValues[multiplyIndex]) = (swappedValues[multiplyIndex], swappedValues[sumSquareIndex]);

            return new TwoPiles(swappedValues);
        }
    }
}
