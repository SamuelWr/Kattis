using System;

namespace a1paper
{
    class Program
    {
        static int[] papers;        //papers[i] == number of A(i) sheets
        static double[] sideLengths;   //      [i] == length of tape required to concatenate two A(i+1) sheets to one A(i)
        static void Main(string[] args)
        {
            int smallest;
            smallest = int.Parse(Console.ReadLine());
            papers = new int[smallest + 1];
            sideLengths = new double[smallest + 1];
            // sideLengths[0] = Math.Pow(2, 0.5);

            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            for (int i = 2; i < papers.Length; i++)
            {
                papers[i] = int.Parse(ss[i - 2]);
            }
            for (int i = 0; i < sideLengths.Length; i++)
            {
                sideLengths[i] = Math.Pow(2, -0.5 * (i) - 0.25);
            }
            //for (int i = 0; i < papers.Length; i++)
            //{
            //    Console.WriteLine($"sidelenght (shorter) of A{i} paper is {sideLengths[i]}");
            //}

            double tape = Conc(1, 1); //length of tape required for 1 A1 paper,
            if (tape < 0)
                Console.WriteLine("impossible");
            else
                Console.WriteLine(tape);
        }

        /// <summary>
        /// Get me numRequired papers of size A[size]
        /// return length of tape reqired for this.
        /// </summary>
        /// <param name="size"></param>
        /// <param name="numRequired"></param>
        /// <returns></returns>
        private static double Conc(int size, int numRequired)
        {
            if (size >= papers.Length)
                return -1;
            if (papers[size] >= numRequired)
                return 0;

            int concatenations = numRequired - papers[size];    //how many papers of this size do I lack?

            double tapeThisStep = concatenations * sideLengths[size];   //tape them together out of smaller
            double tapeLower = 0;
            tapeLower = Conc(size + 1, concatenations * 2);  //give me 2 smaller papers for each time i need to concatenate

            if (tapeLower < 0)  //can't be done. abort
                return tapeLower;

            return tapeLower + tapeThisStep;
        }
    }
}
