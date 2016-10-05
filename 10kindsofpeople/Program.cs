using System;

namespace _10kindsofpeople
{
    class Program
    {
        static int rows, cols;
        static int[,] world;
        static int binaryPartitions = 0;
        static int decimalPartitions = 0;

        static void Main(string[] args)
        {
            //read rows cols.
            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            if (ss.Length != 2)
                throw new ArgumentException("world dimensions badly defined " + s);
            rows = int.Parse(ss[0]);
            cols = int.Parse(ss[1]);

            // read world
            world = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string row = Console.ReadLine();
                // ensure row.Length==cols;
                for (int j = 0; j < row.Length; j++)
                {
                    world[i, j] = int.Parse(row[j] + ""); //Todo: faster!
                }
            }

            //partition world
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Fill(i, j);
                }
            }

            //read number of queries
            int numQueries;
            numQueries = int.Parse(Console.ReadLine());
            if (numQueries < 0 || numQueries > 1000)
                throw new ArgumentException("number of queries badly defined " + numQueries);

            //handles queries
            for (int i = 0; i < numQueries; i++)
            {

                int startRow, startCol;
                int finishRow, finishCol;
                //todo: read positions
                s = Console.ReadLine();
                ss = s.Split(' ');
                startRow = int.Parse(ss[0]) - 1;
                startCol = int.Parse(ss[1]) - 1;
                finishRow = int.Parse(ss[2]) - 1;
                finishCol = int.Parse(ss[3]) - 1;
                if (world[startRow, startCol] == world[finishRow, finishCol])   //in same partition
                {
                    if (world[startRow, startCol] % 2 == 0) //even is binary
                        Console.WriteLine("binary");
                    else
                        Console.WriteLine("decimal");       //odd is decimal
                }
                else
                {
                    Console.WriteLine("neither");
                }
            }

        }
        static void Fill(int row, int col)
        {
            if (world[row, col] > 1)    //already partitioned
                return;
            if (world[row, col] == 0)
            {
                binaryPartitions++;
                Fill(row, col, binaryPartitions * 2);
            }
            else
            {
                decimalPartitions++;
                Fill(row, col, decimalPartitions * 2 + 1);
            }
        }

        static void Fill(int row, int col, int partition)
        {
            if (row < 0 || row > rows - 1)
                return;
            if (col < 0 || col > cols - 1)
                return;
            if (world[row, col] != partition % 2)
                return;
            // valid unfilled position
            world[row, col] = partition;

            Fill(row + 1, col, partition);
            Fill(row - 1, col, partition);
            Fill(row, col + 1, partition);
            Fill(row, col - 1, partition);


        }

    }
}
