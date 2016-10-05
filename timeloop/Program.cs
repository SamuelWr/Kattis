using System;

namespace timeloop
{
    class Program
    {
        static void Main(string[] args)
        {
            int reps = int.Parse(Console.ReadLine());
            for (int i = 0; i < reps; i++)
            {
                Console.WriteLine((i + 1) + " Abracadabra");
            }
        }
    }
}