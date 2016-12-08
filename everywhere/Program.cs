using System;
using System.Collections.Generic;
using System.Linq;

namespace everywhere
{
    class Program
    {
        static void Main(string[] args)
        {
            var cases = int.Parse(Console.ReadLine());
            for (int i = 0; i < cases; i++)
            {
                var numTrips = int.Parse(Console.ReadLine());
                var trips = new List<string>(numTrips);
                for(int j = 0; j < numTrips; j++)
                {
                    trips.Add(Console.ReadLine());
                }
                Console.WriteLine(trips.Distinct().Count());
            }
        }
    }
}
