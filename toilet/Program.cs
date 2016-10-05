using System;

namespace toilet
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            Console.WriteLine(CountFlips(s, Policy.Up));
            Console.WriteLine(CountFlips(s, Policy.Down));
            Console.WriteLine(CountFlips(s, Policy.Desired));
        }
        static ulong CountFlips(string s, Policy policy)
        {
            ulong flips = 0;
            bool isUp = s[0] == 'U' ? true : false;
            for (int i = 1; i < s.Length; i++)
            {
                bool desireUp = s[i] == 'U' ? true : false;
                if (desireUp != isUp)
                    flips++;
                isUp = desireUp;
                switch (policy)
                {
                    case Policy.Up:
                        if (isUp != true)
                            flips++;
                        isUp = true;
                        break;
                    case Policy.Down:
                        if (isUp == true)
                            flips++;
                        isUp = false;
                        break;
                    case Policy.Desired:
                        break;
                }
            }
            return flips;
        }

        enum Policy
        {
            Up,
            Down,
            Desired
        }
    }
}
