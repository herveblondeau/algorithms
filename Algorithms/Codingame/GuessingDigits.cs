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
         |         | => T1/P1  | => T2/P1  |           |           |           |           |           |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    3    | S=4  P=3  | S=5  P=6  | S=6  P=9  |           |           |           |           |           |           |
         |         | => T1/P2  | => T3/P1  | =>  X     |           |           |           |           |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    4    | S=5  P=4  | S=6  P=8  | S=7  P=12 | S=8  P=16 |           |           |           |           |           |
         |         | => T2/P2  | =>  X     | => T4/P1  | => T5/P1  |           |           |           |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    5    | S=6  P=5  | S=7  P=10 | S=8  P=15 | S=9  P=20 | S=10 P=25 |           |           |           |           |
         |         | => T1/P2  | => T1/P2  | => T1/P2  | => T1/P2  | => T1/P2  |           |           |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    6    | S=7  P=6  | S=8  P=12 | S=9  P=18 | S=10 P=24 | S=11 P=30 | S=12 P=36 |           |           |           |
         |         | => T3/P2  | => T4/P2  | =>  X     | =>  X     | => T1/P2  | => T2/P1  |           |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    7    | S=8  P=7  | S=9  P=14 | S=10 P=21 | S=11 P=28 | S=12 P=35 | S=13 P=42 | S=14 P=49 |           |           |
         |         | => T1/P2  | => T1/P2  | => T1/P2  | => T1/P2  | => T1/P2  | => T1/P2  | => T1/P2  |           |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    8    | S=9  P=8  | S=10 P=16 | S=11 P=24 | S=12 P=32 | S=13 P=40 | S=14 P=48 | S=15 P=56 | S=16 P=64 |           |
         |         | =>  X     | => T5/P2  | =>  X     | => T1/P2  | => T1/P2  | => T1/P2  | => T1/P2  | => T1/P2  |           |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         |    9    | S=10 P=9  | S=11 P=18 | S=12 P=27 | S=13 P=36 | S=14 P=45 | S=15 P=54 | S=16 P=63 | S=17 P=72 | S=18 P=81 |
         |         | =>  X     | =>  X     | => T1/P2  | => T2/P1  | => T1/P2  | => T1/P2  | => T1/P2  | => T1/P1  | => T1/P1  |
         |---------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|-----------|
         */
        public Guess GuessDigits(int sum, int product)
        {
            // Pairs will be removed from these dictionaries as the games progresses
            // They keep track of all the pairs associated to each sum and product
            Dictionary<int, List<Pair>> pairsPerSum = new Dictionary<int, List<Pair>>();
            Dictionary<int, List<Pair>> pairsPerProduct = new Dictionary<int, List<Pair>>();
            for (int i = 1; i <=9; i++)
            {
                for (int j = i; j <= 9; j++)
                {
                    if (pairsPerSum.ContainsKey(i + j))
                    {
                        pairsPerSum[i + j].Add(new Pair(i, j));
                    }
                    else
                    {
                        pairsPerSum.Add(i + j, new List<Pair> { new Pair(i, j) });
                    }

                    if (pairsPerProduct.ContainsKey(i * j))
                    {
                        pairsPerProduct[i * j].Add(new Pair(i, j));
                    }
                    else
                    {
                        pairsPerProduct.Add(i * j, new List<Pair> { new Pair(i, j) });
                    }
                }
            }

            int turn = 1;
            int player;
            Pair pair;
            while (true)
            {
                // a) Player 1 (sum)
                player = 1;
                // If unique pair for given sum => found solution
                if (pairsPerSum[sum].Count == 1)
                {
                    pair = pairsPerSum[sum].Single();
                    break;
                }

                // At this stage, player 1 couldn't find the solution, which means that there are at least two pairs matching the given sum
                // So we find all pairs that are unique for their sum...
                var pairsUniqueForTheirSum = new List<Pair>();
                foreach (var s in pairsPerSum.Keys)
                {
                    if (pairsPerSum[s].Count == 1)
                    {
                        pairsUniqueForTheirSum.Add(pairsPerSum[s].Single());
                    }
                }

                // ...and remove them since they cannot be the solution
                foreach (var p in pairsUniqueForTheirSum)
                {
                    pairsPerProduct[p.Product].Remove(p);
                    pairsPerSum.Remove(p.Sum);
                }

                // b) Player 2 (product)
                // Same logic as a) but with the product
                player = 2;
                if (pairsPerProduct[product].Count == 1)
                {
                    pair = pairsPerProduct[product].Single();
                    break;
                }

                var pairsUniqueForTheirProduct = new List<Pair>();
                foreach (var p in pairsPerProduct.Keys)
                {
                    if (pairsPerProduct[p].Count == 1)
                    {
                        pairsUniqueForTheirProduct.Add(pairsPerProduct[p].Single());
                    }
                }

                foreach (var p in pairsUniqueForTheirProduct)
                {
                    pairsPerSum[p.Sum].Remove(p);
                    pairsPerProduct.Remove(p.Product);
                }

                // Special case : if there is no pair we can remove this turn, the solution cannot be determined
                if (pairsUniqueForTheirSum.Count == 0 && pairsUniqueForTheirProduct.Count == 0)
                {
                    return null;
                }

                turn++;
            }

            return new Guess
            {
                Turn = turn,
                Player = player,
                Pair = pair,
            };
        }
    }

    public class Guess
    {
        // Turn number (starting from 1)
        public int Turn { get; set; }

        // Player number (1 or 2)
        public int Player { get; set; }

        public Pair Pair { get; set; }
    }

    public class Pair
    {
        // Lower number
        public int Low { get; set; }

        // Higher number
        public int High { get; set; }

        public Pair(int low, int high)
        {
            Low = low;
            High = high;
        }

        public int Sum => Low + High;
        public int Product => Low * High;

        public override string ToString()
        {
            return "(" + Low + ',' + High + ")";
        }

        public override bool Equals(object obj)
        {
            Pair other = (Pair)obj;
            return Low == other.Low && High == other.High;
        }

        public override int GetHashCode()
        {
            return Low * 10 + High;
        }
    }
}