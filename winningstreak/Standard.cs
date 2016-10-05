using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winningstreak
{
    static class Standard
    {
        static Dictionary<int, double> cache;
        static double[] powerCache;

        public static double ComputeAverageStreak(int numMatches, double pWin)
        {
            cache = new Dictionary<int, double>();
            powerCache = new double[numMatches + 1];

            var average = 0d;

            for (int streakLength = 1; streakLength <= numMatches; streakLength++)
            {
                average += ProbStreakAtLeast(streakLength, numMatches, pWin);
            }
            return average;
        }

        private static double ProbStreakAtLeast(int streakLength, int numMatches, double pWin)
        {
            if (cache.ContainsKey(key(streakLength, numMatches)))
            {
                return cache[key(streakLength, numMatches)];
            }
            if (streakLength > numMatches)
                return 0;
            if (streakLength == 0)
                return 1;
            if (streakLength == numMatches)
                return cachedPower(pWin, streakLength);
            //probability of already having it without the final match,
            var probability = ProbStreakAtLeast(streakLength, numMatches - 1, pWin);

            //probability of not having it in the first few elements, and then having a loss, and finally the desired streak
            //i.e. there was no streak, but the final match created it.
            probability += (1 - ProbStreakAtLeast(streakLength, numMatches - (streakLength + 1), pWin))//probability of not having a streak in first matches
                            * (1 - pWin) * cachedPower(pWin, streakLength);
            cache.Add(key(streakLength, numMatches), probability);
            return probability;
        }
        private static int key(int streakLength, int numMatches)
        {
            //number of matches <= 3000, so there is no risk of cache collision.
            return streakLength * 3002 + numMatches;
        }
        private static double cachedPower(double x, int y)
        {
            if (powerCache[y] != 0)
                return powerCache[y];
            powerCache[y] = Math.Pow(x, y);
            return powerCache[y];
        }
    }
}
