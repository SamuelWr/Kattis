using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winningstreak
{
    class Program
    {
        static void Main(string[] args)
        {
            var scanner = new Kattis.IO.Scanner();
            //var writer = new Kattis.IO.BufferedStdoutWriter();
            while (scanner.HasNext())
            {
                int numMatches = scanner.NextInt();
                double pWin = scanner.NextDouble();

                var timer = new Stopwatch();
                timer.Start();
                var average = Standard.ComputeAverageStreak(numMatches, pWin);
                timer.Stop();
                Console.WriteLine("STANDARD:");
                Console.WriteLine($"{average} Calculated in: {timer.ElapsedMilliseconds}ms");
                //writer.Write(average);
                //timer.Restart();
                //average = Naive.ComputeAverageStreak(numMatches, pWin);
                //Console.WriteLine($"Calculated in: {timer.ElapsedMilliseconds}ms, average={average}");
                //Console.WriteLine(average);
                timer.Restart();
                average = Optimized.ComputeAverageStreak(numMatches, pWin);
                timer.Stop();
                Console.WriteLine("OPTIMIZED:");
                Console.WriteLine($"{average} Calculated in: {timer.ElapsedMilliseconds}ms");

            }
            //writer.Flush();
        }
    }
}
