using System;
using System.Collections.Generic;
// https://www.codingame.com/training/expert/the-lucky-number

namespace Codingame.TheLuckyNumber
{
    public class TheLuckyNumber
    {
        /// <summary>
        /// Counts the number of lucky numbers between two values, inclusive
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns>The number of lucky values between <paramref name="min"/> and <paramref name="max"/></returns>
        public long Count(long min, long max)
        {
            return Count(max) - Count(min-1);
        }

        /// <summary>
        /// Counts the number of lucky numbers between 0 and a given number
        /// </summary>
        /// <param name="n"></param>
        /// <returns>The number of lucky values between 0 and <paramref name="n"/></returns>
        public long Count(long n)
        {
            /*
                Iteratively checking whether each number between 0 and 1 is lucky would be easy, but way too slow for large numbers
                Our approach instead counts the lucky numbers for "blocks of powers of 10" using simple mathematical formulas, then add up the results.

                For example, with 7328, we "simply" count the number of lucky numbers in the following blocks, and sum the results:
                - blocks of size 1000 (10^3):
                    - 0 to 999     -> 434 lucky numbers
                    - 1000 to 1999 -> 434 lucky numbers
                    - 2000 to 2999 -> 434 lucky numbers
                    - 3000 to 3999 -> 434 lucky numbers
                    - 4000 to 4999 -> 434 lucky numbers
                    - 5000 to 5999 -> 434 lucky numbers
                    - 6000 to 6999 -> 729 lucky numbers
                - blocks of size 100 (10^2):
                    - 7000 to 7099 -> 34 lucky numbers
                    - 7100 to 7199 -> 34 lucky numbers
                    - 7200 to 7299 -> 34 lucky numbers
                - blocks of size 10 (10^1):
                    - 7300 to 7309 -> 2 lucky numbers
                    - 7310 to 7319 -> 2 lucky numbers
                - blocks of size 1 (10^0):
                    - 7320 -> no lucky number
                    - 7321 -> no lucky number
                    - 7322 -> no lucky number
                    - 7323 -> no lucky number
                    - 7324 -> no lucky number
                    - 7325 -> no lucky number
                    - 7326 -> 1 lucky number
                    - 7327 -> no lucky number
                    - 7328 -> 1 lucky number
                => 3441 lucky numbers

                In order to compute the blocks, we use the following principles:
                1) we don't just count the number of lucky numbers for a block, we keep track of the count of each category of numbers:
                  - unlucky with neither 6 or 8
                  - unlucky with both 6 or 8
                  - lucky with 6
                  - lucky with 8
                  This is referred to as the detailed count, and is necessary for principle 3)
                2) we never iterate over the numbers, instead we use simple mathematical formulas to calculate the detailed count for blocks of numbers between 0 and any power of 10 (explanations in the method that does the detailed count). This gives us the detailed count for 0-9, 0-99, 0-999 etc.
                3) once we have the detailed count for a 0-10^n block, we can easily deduce the detailed count for the same block but with an extra digit prepended (explanations in the DetailedCount class). So, if we have the detailed count for 0-999, we can obtain the detailed count for 1000-1999, 2000-2999 etc. And by iteration, we can obtain the detailed count of any larger block

                So, with the 7328 example above:
                - blocks of size 1000:
                    - principle 2 gives the detailed count for 0-999
                    - using principle 3, we deduce the detailed count for 1000-1999,..., 6000-6999
                - blocks of size 100:
                    - principle 2 gives the detailed count for 0 to 99
                    - using principle 3, we deduce the detailed count for 7000 to 7099,..., 7200-7299
                - blocks of size 10:
                    - principle 2 gives the detailed count for 0 to 9
                    - using principle 3, we deduce the detailed count for 7300 to 7309, 7310-7319
                - blocks of size 1:
                    - principle 2 gives the detailed count for 0 to 0
                    - using principle 3, we deduce the detailed count for 7320,..., 7328

                We split a number into three parts:
                - prefix: the digits that don't change for a given block size. For instance, with blocks of size 10, the base is the first 2 digits ("73" in the example above)
                - group: the digit that varies for a given block size. For instance, with blocks of size 100, the group is the second digit (varies between 0 to 2 in the example above)
                - remainder: the remaining digits, which define the block size. For instance, with blocks of size 100, the remainder is the last 2 digits. We don't use the digits themselves, what matters is the size of the remainder, which determines the block size

                These three parts mutate during the process: basically, as we iterate, digits from the remainder "move to the left": the first digit of the remainder becomes the group, and the group is moved to the prefix
             */

            // Debug
            // Console.WriteLine($"Number: {n}");

            long nbLucky = 0;

            // Initially, all digits are in the remainder
            List<int> remainder = new();
            while (n > 0)
            {
                remainder.Insert(0, (int)(n % 10));
                n /= 10;
            }

            var nbDigits = remainder.Count; // since we are going to mutate the remainder, we need to store its initial number of elements
            int group = -1;
            List<int> prefix = new();
            for (int i = 0; i < nbDigits; i++)
            {
                // Move the first digit of the remainder to the left, taking the place of the group, and push the group to the prefix: for example, 7-3-28 becomes 73-2-8
                if (group != -1)
                {
                    prefix.Add(group);
                }
                group = remainder[0];
                remainder.RemoveAt(0);

                // Debug
                // Console.WriteLine();
                // string debugPrefix = string.Join("", prefix);
                // string debugRemainder = string.Join("", remainder);
                // Console.WriteLine($"({debugPrefix})-({group})-({debugRemainder})");
                // Console.WriteLine(group > 0
                //     ? $"Add 10^{remainder.Count} increments with prefixes {debugPrefix}0 to {debugPrefix}{group - 1}"
                //     : $"No 10^{remainder.Count} increment"
                // );

                for (int j = 0; j < group + (remainder.Count == 0 ? 1 : 0); j++)
                {
                    DetailedCount count = _getDetailedCountToPowerOf10(remainder.Count) // Use principle 2 to get the detailed count for the remainder size
                        .AddDigit(j); // Then use principle 3 to prepend the current group...
                    foreach (var digit in prefix)
                    {
                        count.AddDigit(digit); // ...and the prefix
                    }

                    // Debug
                    // string debugStart;
                    // string debugEnd;
                    // if (remainder.Count > 0)
                    // {
                    //     debugStart = $"{debugPrefix}{j}{new('0', remainder.Count - 1)}0";
                    //     debugEnd = $"{debugPrefix}{j}{new('9', remainder.Count - 1)}9";
                    //     Console.WriteLine($"- from {debugStart} to {debugEnd} -> {count.LuckySix + count.LuckyEight}");
                    // }
                    // else
                    // {
                    //     debugStart = $"{debugPrefix}{j}";
                    //     Console.WriteLine($"- {debugStart} -> {count.LuckySix + count.LuckyEight}");
                    // }

                    nbLucky = nbLucky + count.LuckySix + count.LuckyEight;
                }
            }

            // Debug
            // Console.WriteLine();
            // Console.WriteLine($"=> Nb lucky numbers: {nbLucky}");
            // Console.WriteLine();

            return nbLucky;
        }

        /// <summary>
        /// Computes the detailed count for the block of numbers between 0 and 10^n
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private DetailedCount _getDetailedCountToPowerOf10(int n)
        {
            // Total space: 10 possibilities for each digit
            long total = (long)Math.Pow(10, n);

            // Unlucky numbers with neither a 6 nor a 8: 8 possibilities for each digit
            long unluckyNone = (long)Math.Pow(8, n);

            // Lucky numbers: explanations in the method
            long lucky = _countToPowerOf10(n);

            // Unlucky numbers with both 6s and 8s
            long unluckyTwo = total - unluckyNone - lucky;

            return new DetailedCount
            {
                UnluckyNone = unluckyNone,
                LuckySix = lucky / 2,
                LuckyEight = lucky / 2,
                UnluckyTwo = unluckyTwo,
            };
        }

        // Counts the number of lucky numbers between 0 and 10^n (in other words, numbers up to n digits)
        private long _countToPowerOf10(int exponent)
        {
            /*
                Example: compute the number of lucky numbers up to 4 digits that only contain 6s
                Those lucky numbers can contain either 1, 2, 3 or 4 6s
                - one 6: 6XXX, X6XX, XX6X, XXX6 -> 4 groups
                - two 6s: 66XX, 6X6X, 6XX6, X66X, X6X6, XX66 -> 6 groups
                - three 6s: 666X, 66X6, 6X66, X666 -> 4 groups
                - four 6s: 6666 -> 1 group
                In other words, the number of groups is the sum of the numbers of combinations of k elements among n, where 1<=k<=n (https://en.wikipedia.org/wiki/Combination).

                Then, To get the number of lucky numbers, we have to count the Xs for each group, where X can be any digit except 6 or 8
             */
            long nbInstances = 0;
            for (int k = 1; k <= exponent; k++)
            {
                nbInstances += _combinations(k, exponent) * (long)Math.Pow(8, exponent - k);
            }

            return nbInstances * 2; // multiply by 2 since the calculation above was only for one digit (6 or 8, not both)
        }

        private long _combinations(int k, int n)
        {
            return _factorial(n) / (_factorial(k) * _factorial(n - k));
        }

        private long _factorial(long n)
        {
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        private class DetailedCount
        {
            public long LuckySix { get; set;}
            public long LuckyEight { get; set;}
            public long UnluckyNone { get; set;}
            public long UnluckyTwo { get; set;}

            public DetailedCount Add(DetailedCount other)
            {
                return new DetailedCount
                {
                    LuckySix = LuckySix + other.LuckySix,
                    LuckyEight = LuckyEight + other.LuckyEight,
                    UnluckyNone = UnluckyNone + other.UnluckyNone,
                    UnluckyTwo = UnluckyTwo + other.UnluckyTwo,
                };
            }

            // Recompute the detailed count when adding a digit
            public DetailedCount AddDigit(int digit)
            {
                if (digit == 6)
                {
                    // When adding a 6:
                    // - lucky numbers with a 6 remain as is
                    // - lucky numbers with a 8 become unlucky
                    // - unlucky numbers with both 6 and 8 remain as is
                    // - unlucky numbers with neither 6 nor 8 become lucky
                    (LuckySix, LuckyEight, UnluckyNone, UnluckyTwo) = (UnluckyNone + LuckySix, 0, 0, UnluckyTwo + LuckyEight);
                }
                else if (digit == 8)
                {
                    (LuckySix, LuckyEight, UnluckyNone, UnluckyTwo) = (0, UnluckyNone + LuckyEight, 0, UnluckyTwo + LuckySix);
                }

                return this;
            }
        }
    }
}
