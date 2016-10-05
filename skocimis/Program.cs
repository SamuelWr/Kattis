using System;


namespace skocimis
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            int A, B, C;
            A = int.Parse(ss[0]);
            B = int.Parse(ss[1]);
            C = int.Parse(ss[2]);

            int interval1 = C - B - 1;
            int interval2 = B - A - 1;

            int answer = interval1 > interval2 ? interval1 : interval2;

            Console.WriteLine(answer);
        }
    }
}
