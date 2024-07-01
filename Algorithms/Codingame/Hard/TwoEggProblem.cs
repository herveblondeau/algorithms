// https://www.codingame.com/training/hard/google-interview---the-two-egg-problem

using System;

namespace Codingame.Hard.TwoEggProblem;

public class TwoEggProblem
{
    /**
     * This is a classic riddle
     * Let n be the number of floors and x the floor from which we drop the first egg. The strategy goes as follows:
     * - if it breaks, then the threshold is lower than x. We then drop the second egg from the first floor, then second etc. until it breaks too, which will happen at the latest on the x-1th floor. The maximum number of drops is x.
     * - if it doesn't break, we drop it from the x-1th floor:
     *   - if it breaks, then the threshold is lower than x-1. We then drop the second egg from the first floor, then second etc. until it breaks too, which will happen at the latest on the x-2th floor. The maximum number of drops is x again.
     *   - if it doesn't break, we drop it from the x-2th floor, following the same strategy as above, and so on...
     * With this strategy, the maximum number of drops is always x
     *
     * In other words, to solve this riddle, we have to find x for which 1+2+...+x >= n
     * This is equivalent to x(x+1)/2 >= n, i.e. x²+x-2n >= 0 in the polynomial form
     * This second-degree equation has two solutions:
     * (-1-sqrt(1+8n))/2 and (-1+sqrt(1+8n))/2, of which only the latter is positive and therefore the one we are looking for
     * This is of course a decimal number, so we need to round it up to the nearest integer
     */
    public int GetMinimumDrops(int floors)
    {
        return (int)Math.Ceiling((-1 + Math.Sqrt(1 + 8 * floors)) / 2);
    }
}