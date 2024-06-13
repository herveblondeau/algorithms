// https://www.codingame.com/training/expert/heart-of-the-city

using System;

namespace Codingame.HeartOfTheCity
{
    public class HeartOfTheCity
    {
        // TODO: Complexity: O(n log log n) time, O(n) space
        // TODO: optimize and/or fix: the final Codingame hidden test case doesn't pass
        // TODO: develop explanations
        public long GetNumberOfVisibleBuildings(long citySize)
        {
            if (citySize % 2 == 0)
            {
                throw new ArgumentException("City size must be even");
            }

            if (citySize < 3 || citySize > 10000000)
            {
                throw new ArgumentException("City size must be between 5 and 9999999");
            }

            // Since the city is symmetrical, each quadrant is identical, and since we are in the center, we can make the computation on one quadrant
            long n = citySize / 2;

            // Actually, the problem comes down to computing the number of coprime numbers in the range 1-n
            // which matches the number of visible buildings in a semi-quadrant

            // Sieve of Erasthothenes algorithm to find all primes up to n
            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }
            for (int i = 2; i * i <= n; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            // Instead of computing and storing all prime divisors of each number, we only store the smallest one
            // By iterating backward, we can find all of them
            // For instance with 60:
            // - smallest divisor: 2 => 60 / 2 = 30
            // - smallest divisor of 30: 2 => 30 / 2 = 15
            // - smallest divisor of 15: 3 => 15 / 3 = 5
            // - smallest divisor of 5: 5 => 5 / 5 = 1
            // => 2, 2, 3, 5
            long[] smallestPrimeFactors = new long[n + 1];
            for (int i = 2; i <= n; i++)
            {
                if (!isPrime[i])
                {
                    continue;
                }

                for (long j = i; j <= n; j += i)
                {
                    if (smallestPrimeFactors[j] == 0)
                    {
                        smallestPrimeFactors[j] = i;
                    }
                }
            }

            long nbCoprimesInSemiQuadrant = 0;
            for (int i = 2; i <= n; i++)
            {
                nbCoprimesInSemiQuadrant += _getNbCoprimes(i, smallestPrimeFactors);
            }

            return nbCoprimesInSemiQuadrant * 8 + 8;
        }

        private long _getNbCoprimes(long n, long[] smallestPrimeFactors)
        {
            long lastSmallestPrimeFactor = -1;
            long nbCoprimes = n;
            long currentSmallestPrimeFactor;
            while (n > 1)
            {
                currentSmallestPrimeFactor = smallestPrimeFactors[n];
                if (currentSmallestPrimeFactor != lastSmallestPrimeFactor)
                {
                    nbCoprimes = nbCoprimes * (currentSmallestPrimeFactor - 1) / currentSmallestPrimeFactor;
                }
                n /= currentSmallestPrimeFactor;
                lastSmallestPrimeFactor = currentSmallestPrimeFactor;
            }

            return nbCoprimes;
        }
    }
}
