// https://www.codingame.com/training/medium/the-gift

using System;
using System.Collections.Generic;
using System.Linq;

namespace Codingame.TheGift
{
    public class TheGift
    {
        public Result ComputeContributions(int[] budgets, int total)
        {
            Array.Sort(budgets);
            int[] contributions = new int[budgets.Length];

            int remainingAmount = total;
            int nbRemainingContributors = budgets.Length;
            for (int i = 0; i < budgets.Length; i++)
            {
                if (budgets[i] >= remainingAmount / nbRemainingContributors)
                    contributions[i] = remainingAmount / nbRemainingContributors;
                else
                    contributions[i] = budgets[i];

                remainingAmount -= contributions[i];
                nbRemainingContributors--;
            }

            return new Result
            {
                IsSolvable = remainingAmount == 0,
                Contributions = contributions,
            };
        }
    }

    public class Result
    {
        public bool IsSolvable { get; set; }
        public int[] Contributions { get; set; }
    }
}