// https://www.codingame.com/training/hard/timer-for-clash-of-code

using System;

namespace Codingame.TimerForClashOfCode
{
    public class TimerForClashOfCode
    {
        public int GetStartTime(int[] arrivalTimes)
        {
            if (arrivalTimes.Length == 0)
            {
                return -1;
            }

            int nbPlayers = 1;
            int elapsed = 0;
            int timer = 300;
            int untilStart = 300;
            int untilNextArrival;

            foreach (var nextArrival in arrivalTimes)
            {
                nbPlayers++;

                // Compute time until arrival
                untilNextArrival = nextArrival - elapsed;

                if (untilNextArrival > untilStart)
                {
                    timer -= untilStart;
                    return timer;
                }

                elapsed += untilNextArrival;
                timer -= untilNextArrival;

                untilStart = (int)(256 / Math.Pow(2, nbPlayers - 2));
            }

            timer = Math.Max(timer - untilStart, 0);

            return timer;
        }
    }
}
