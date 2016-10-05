using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winningstreak
{
    static class Naive
    {
        public static double ComputeAverageStreak(int numMatches, double pWin)
        {
            var average = 0d;
            if (numMatches > 31)
                throw new OverflowException("Integer overflow in naive algorithm. No more than 31 matches!");
            int cases = (1 << numMatches) - 1;
            for (int i = 0; i <= cases; i++)
            {
                int wins = 0, losses = 0, longestStreak = 0;
                int currStreak = 0;
                int currCase = i;
                for (int j = 0; j < numMatches; j++)
                {
                    if (currCase % 2 == 0)
                    {
                        currStreak = 0;
                        losses++;
                    }
                    else
                    {
                        currStreak++;
                        wins++;
                        if (currStreak > longestStreak)
                            longestStreak = currStreak;
                    }
                    currCase = currCase >> 1;
                }
                average += longestStreak * Math.Pow(pWin, wins) * Math.Pow(1 - pWin, losses);
            }

            return average;
        }
    }
}
