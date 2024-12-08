// https://www.codingame.com/training/easy/bank-robbers

using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame.Easy.BankRobbers;

public class BankRobbers
{
    public int ComputeHeistTime(int nbRobbers, List<(int, int)> vaultDescriptions)
    {
        // The vaults represent sequential work to perform and are modeled as a queue. Each entry is the number of combinations for a vault
        Queue<int> vaults = new Queue<int>();

        foreach (var description in vaultDescriptions)
        {
            int nbCharacters = description.Item1;
            int nbDigits = description.Item2;
            vaults.Enqueue(Convert.ToInt32(Math.Pow(10, nbDigits) * Math.Pow(5, nbCharacters - nbDigits)));
        }

        // The robbers represent workers and are modeled as an array. Each entry is the number of remaining combinations for a robber
        int[] robbers = new int[nbRobbers];

        // Execute the heist
        int totalSeconds = 0;
        bool hasRemainingWork = true;
        while (hasRemainingWork)
        {
            // Assign available robbers to vaults
            for (int i = 0; i < robbers.Length; i++)
            {
                if (robbers[i] == 0 && vaults.Count > 0)
                {
                    robbers[i] = vaults.Dequeue();
                }
            }

            // Perform one round: just enough work for the least busy robber(s) to exhaust the combinations for their vault
            int nbSeconds = robbers.Where(n => n > 0).Min();
            totalSeconds += nbSeconds;
            for (int i = 0; i < robbers.Length; i++)
            {
                robbers[i] -= nbSeconds;
            }

            // At least one vault remaining or at least one robber with still work to perform?
            hasRemainingWork = vaults.Count > 0 || robbers.Any(n => n > 0);
        }

        return totalSeconds;
    }
}
