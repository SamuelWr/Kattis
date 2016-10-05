using System;

namespace mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            int length = int.Parse(ss[0]);
            string code = ss[1];
            string guess = ss[2];
            int correct = 0;
            int charmatch = 0;
            int[,] alphabeth = new int[2, 'Z' - 'A' + 1];

            for (int i = 0; i < length; i++)
            {
                // fully correct here
                if (code[i] == guess[i])
                    correct++;
                //count characters here
                alphabeth[0, code[i] - 'A']++;
                alphabeth[1, guess[i] - 'A']++;
            }
            for (int i = 0; i < alphabeth.GetLength(1); i++)
            {

                charmatch += alphabeth[0, i] > alphabeth[1, i] ? alphabeth[1, i] : alphabeth[0, i];
            }
            charmatch -= correct;
            Console.WriteLine(correct + " " + charmatch);

        }
    }
}
