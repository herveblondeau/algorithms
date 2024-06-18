// https://www.codingame.com/training/expert/heart-of-the-city

using System;

namespace Codingame.HeartOfTheCity;

public class HeartOfTheCity
{
    public long GetNumberOfVisibleBuildings(long citySize)
    {
        if (citySize % 2 == 0)
        {
            throw new ArgumentException("City size must be odd");
        }

        if (citySize < 3 || citySize > 10000000)
        {
            throw new ArgumentException("City size must be between 3 and 9999999");
        }

        // Since the city is symmetrical, each quadrant is identical, and since we are in the center, we can make the computation on one quadrant
        long n = citySize / 2;

        // Upon further analysis, it turns out that the problem can actually be solved on a semi-quadrant
        // and consists in computing the number of coprime pairs (pairs of numbers with no common divisor) in the range 1-n
        // For instance, 21 and 10 are coprimes while 21 and 15 are not

        // We therefore need to know all divisors of every number
        // Because this would take too much space to store, we only keep track of the smallest divisor of each number
        // This will allow us to find all divisors by iteration

        // The first step is to find all primes, using the Sieve of Erastothenes algorithm
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

        // Next, find the smallest divisor for each number
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
