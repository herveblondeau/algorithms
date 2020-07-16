// https://www.codingame.com/training/medium/guessing-digits

using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame.GuessingDigits
{
    public class GuessingDigits
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="product"></param>
        /// <returns>
        /// - Guess object (null if unsolvable)
        /// </returns>
        /*
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |         |     1     |     2     |     3     |     4     |     5     |     6     |     7     |     8     |     9     |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    1    | S=2  P=1  |           |           |           |           |           |           |           |           |
         |         | => T1/P1  |           |           |           |           |           |           |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    2    | S=3  P=2  | S=4  P=4  |           |           |           |           |           |           |           |
         |         | => T1/P1  | => T /P   |           |           |           |           |           |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    3    | S=4  P=3  | S=5  P=6  | S=6  P=9  |           |           |           |           |           |           |
         |         | => T /P   | => T /P   | => T /P   |           |           |           |           |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    4    | S=5  P=4  | S=6  P=8  | S=7  P=12 | S=8  P=16 |           |           |           |           |           |
         |         | => T /P   | => T /P   | => T /P   | => T /P   |           |           |           |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    5    | S=6  P=5  | S=7  P=10 | S=8  P=15 | S=9  P=20 | S=10 P=25 |           |           |           |           |
         |         | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   |           |           |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    6    | S=7  P=6  | S=8  P=12 | S=9  P=18 | S=10 P=24 | S=11 P=30 | S=12 P=36 |           |           |           |
         |         | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   |           |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    7    | S=8  P=7  | S=9  P=14 | S=10 P=21 | S=11 P=28 | S=12 P=35 | S=13 P=42 | S=14 P=49 |           |           |
         |         | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    8    | S=9  P=8  | S=10 P=16 | S=11 P=24 | S=12 P=32 | S=13 P=40 | S=14 P=48 | S=15 P=56 | S=16 P=64 |           |
         |         | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    9    | S=10 P=9  | S=11 P=18 | S=12 P=27 | S=13 P=36 | S=14 P=45 | S=15 P=54 | S=16 P=63 | S=17 P=72 | S=18 P=81 |
         |         | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   | => T /P   | => T1/P1  | => T1/P1  |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         */
        public Guess GuessDigits(int sum, int product)
        {
            Dictionary<int, List<(int, int)>> pairsPerSum = new Dictionary<int, List<(int, int)>>();
            Dictionary<int, List<(int, int)>> pairsPerProduct = new Dictionary<int, List<(int, int)>>();

            for (int i = 1; i <=9; i++)
            {
                for (int j = i; j <= 9; j++)
                {
                    if (pairsPerSum.ContainsKey(i + j))
                    {
                        pairsPerSum[i + j].Add((i, j));
                    }
                    else
                    {
                        pairsPerSum.Add(i + j, new List<(int, int)> { (i, j) });
                    }

                    if (pairsPerProduct.ContainsKey(i * j))
                    {
                        pairsPerProduct[i * j].Add((i, j));
                    }
                    else
                    {
                        pairsPerProduct.Add(i * j, new List<(int, int)> { (i, j) });
                    }
                }
            }

            int turn = 1;
            int player = 1;
            int low = 0;
            int high = 0;
            while (true)
            {
                // a) Player 1 (sum)
                player = 1;
                // - if unique pair for given sum => found solution
                if (pairsPerSum[sum].Count == 1)
                {
                    low = pairsPerSum[sum].Single().Item1;
                    high = pairsPerSum[sum].Single().Item2;
                    break;
                }

                // - find all pairs that have a unique sum...
                //var pairsWithUniqueSum = pairsPerSum.Where(x => x.Value.Count == 1).SelectMany(x => new List<(int, int)>(x.Value));
                var pairsWithUniqueSum = new List<(int, int)>();
                foreach (var s in pairsPerSum.Keys)
                {
                    if (pairsPerSum[s].Count == 1)
                    {
                        pairsWithUniqueSum.Add(pairsPerSum[s][0]);
                    }
                }

                // ...and remove them
                foreach (var pair in pairsWithUniqueSum)
                {
                    pairsPerProduct[pair.Item1 * pair.Item2].Remove(pair);
                    pairsPerSum.Remove(pair.Item1 + pair.Item2);
                }

                // b) Player 2 (product)
                player = 2;
                // - if unique pair for given product => found solution
                if (pairsPerProduct[product].Count == 1)
                {
                    low = pairsPerProduct[product].Single().Item1;
                    high = pairsPerProduct[product].Single().Item2;
                    break;
                }

                // - find all pairs that have a unique product...
                var pairsWithUniqueProduct = new List<(int, int)>();
                foreach (var s in pairsPerProduct.Keys)
                {
                    if (pairsPerProduct[s].Count == 1)
                    {
                        pairsWithUniqueProduct.Add(pairsPerProduct[s][0]);
                    }
                }

                // ...and remove them
                foreach (var pair in pairsWithUniqueProduct)
                {
                    pairsPerSum[pair.Item1 + pair.Item2].Remove(pair);
                    pairsPerProduct.Remove(pair.Item1 * pair.Item2);
                }

                if (pairsWithUniqueSum.Count == 0 && pairsWithUniqueProduct.Count == 0)
                {
                    return null;
                }

                turn++;
            }

            return new Guess
            {
                Turn = turn,
                Player = player,
                Low = low,
                High = high,
            };
        }
    }

    public class Guess
    {
        // Turn number (starting from 1)
        public int Turn { get; set; }

        // Player number (1 or 2)
        public int Player { get; set; }

        // Lower number
        public int Low { get; set; }

        // Higher number
        public int High { get; set; }

    }
}