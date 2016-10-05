using System;

namespace nine
{
    class Program
    {
        static int mod = 1000000007;
        static void Main(string[] args)
        {
            int numCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < numCases; i++)
            {
                long possibilities = Case();
                Console.WriteLine(possibilities);
            }

        }

        private static long Case()
        {
            long digits = long.Parse(Console.ReadLine());
            if (digits == 0)
                return 0;
            long ans = 8;
            digits--;

            ans *= subCase(digits);
            ans = ans % mod;


            return ans;
        }

        private static long subCase(long digits)
        {
            long ans;
            if (digits % 2 == 1)
                ans = (9 * subCase(digits - 1)) % mod;
            else if (digits == 0)
                ans = 1;
            else
            {
                ans = subCase(digits / 2);
                ans = ans * ans;
                ans = ans % mod;
            }
            return ans;

        }
    }
}
