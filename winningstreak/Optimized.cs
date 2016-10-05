using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winningstreak
{
    static class Optimized
    {
        static Dictionary<int, double> cache;
        static double[] powerCache;
        static double pWin;
        public static double ComputeAverageStreak(int numMatches, double pWin)
        {
            powerCache = new double[numMatches + 1];
            Optimized.pWin = pWin;

            var average = 0d;
            /*
             * Sum(n=0 => n=k)n*P(Longest=n) == Sum(n=0 => n=k)P(longest >= n)
             */
            for (int streakLength = 1; streakLength <= numMatches; streakLength++)
            {
                cache = new Dictionary<int, double>();
                average += ProbStreakAtLeast(streakLength, numMatches);
            }
            return average;
        }
        private static double ProbStreakAtLeast(int streakLength, int numMatches)
        {
            double[] localCache = new double[numMatches + 1];
            localCache[streakLength] = cachedPower(streakLength);
            for (int i = streakLength+1; i < localCache.Length; i++)
            {
                //streak length is minimum 1, so i-1 is never outside array bounds.

                double previousProb = localCache[i - 1];

                double probLower = i - (streakLength + 1) >= 0 ? localCache[i - (streakLength + 1)] : 0;

                double newProb = (1 - probLower)//probability of not having a streak in first matches
                            * (1 - pWin) * cachedPower(streakLength);


                localCache[i] = previousProb + newProb;
            }
            return localCache[numMatches];
        }

        //TODO: replace this method with a array of precalculated values.
        private static double cachedPower(int exponent)
        {
            if (powerCache[exponent] != 0)
                return powerCache[exponent];
            powerCache[exponent] = Math.Pow(pWin, exponent);
            return powerCache[exponent];
        }
    }
}
