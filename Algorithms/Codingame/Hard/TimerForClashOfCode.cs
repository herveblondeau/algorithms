// https://www.codingame.com/training/hard/timer-for-clash-of-code

using System;

namespace Codingame.TimerForClashOfCode
{
    public class TimerForClashOfCode
    {
        public int GetStartTime(int[] arrivals)
        {
            if (arrivals.Length == 0)
            {
                return -1;
            }

            int nbPlayers = 1;
            int timer = 300;
            int untilStart = 300;
            int untilNextArrival;

            foreach (var nextArrival in arrivals)
            {
                // No arrival soon enough: start at expiration
                untilNextArrival = timer - nextArrival;
                if (untilNextArrival > untilStart)
                {
                    timer -= untilStart;
                    return timer;
                }

                // Arrival before expiration
                timer -= untilNextArrival;

                // Start immediately if room is filled
                if (++nbPlayers == 8)
                {
                    return timer;
                }

                // Recompute expiration delay
                untilStart = (int)(256 / Math.Pow(2, nbPlayers - 2)); // the formula given in the problem is slightly off; it is not players minus 1 but players minus 2
            }

            // No final arrival: start at expiration
            timer = Math.Max(timer - untilStart, 0);

            return timer;
        }

        public static int ToSeconds(string mSs)
        {
            var components = mSs.Split(':');
            int minutes = int.Parse(components[0]);
            int seconds = int.Parse(components[1]);

            return minutes * 60 + seconds;
        }

        public static string ToMSs(int seconds)
        {
            int minutes = seconds / 60;
            seconds = seconds % 60;
            return seconds >= 10 ? $"{minutes}:{seconds}"
                : seconds > 0 ? $"{minutes}:0{seconds}"
                : $"{minutes}:{seconds}0";
        }
    }
}
