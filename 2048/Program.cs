using System;

namespace _2048
{
    class Program
    {
        static int[,] state = new int[4, 4];
        static void Main(string[] args)
        {

            for (int i = 0; i < 4; i++)
            {
                string s = Console.ReadLine();
                string[] ss = s.Split(' ');
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] = int.Parse(ss[j]);
                }
            }

            var key = int.Parse(Console.ReadLine());
            switch (key)
            {
                case 0:
                    left();
                    break;
                case 2:
                    right();
                    break;
                case 1:
                    up();
                    break;
                case 3:
                    down();
                    break;
                default:
                    break;
                    //throw new NotSupportedException("not a supported key");
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(state[i, j]);
                    if (j < 3)
                        Console.Write(" ");
                }
                Console.WriteLine();
            }


        }
        static void left()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    left(i, j);
                }
            }
        }

        private static void left(int row, int col)
        {
            int currCol = col;
            if (state[row, col] == 0)
            {
                //look right for non empty
                while (currCol < 4 && state[row, col] == 0)
                {
                    if (state[row, currCol] != 0)
                    {
                        state[row, col] = state[row, currCol];
                        state[row, currCol] = 0;
                    }
                    currCol++;
                }
            }
            //look right for merge.
            bool merge = false;
            for (int i = col + 1; i < 4 && !merge; i++)
            {
                if (state[row, i] != 0)
                    merge = true;
                if (state[row, col] == state[row, i])
                {
                    state[row, col] *= 2;
                    state[row, i] = 0;
                }
            }
        }

        static void right()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 3; j >= 0; j--)
                {
                    right(i, j);
                }
            }

        }

        private static void right(int row, int col)
        {
            if (state[row, col] == 0)
            {
                //look left for non empty
                for (int i = col - 1; i >= 0 && state[row, col] == 0; i--)
                {
                    if (state[row, i] != 0)
                    {
                        state[row, col] = state[row, i];
                        state[row, i] = 0;
                    }
                }

            }
            //look left for merge.
            bool merge = false;
            for (int i = col - 1; i >= 0 && !merge; i--)
            {
                if (state[row, i] != 0)
                    merge = true;
                if (state[row, col] == state[row, i])
                {
                    state[row, col] *= 2;
                    state[row, i] = 0;
                }
            }
        }

        static void up()
        {
            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    up(row, col);
                }
            }
        }

        private static void up(int row, int col)
        {
            if (state[row, col] == 0)
            {
                //look down for non empty
                for (int i = row + 1; i < 4 && state[row, col] == 0; i++)
                {
                    if (state[i, col] != 0)
                    {
                        state[row, col] = state[i, col];
                        state[i, col] = 0;
                    }
                }

            }
            //look down for merge.
            bool merge = false;
            for (int i = row + 1; i < 4 && !merge; i++)
            {
                if (state[i, col] != 0)
                    merge = true;
                if (state[row, col] == state[i, col])
                {
                    state[row, col] *= 2;
                    state[i, col] = 0;
                }
            }
        }

        static void down()
        {
            for (int col = 0; col < 4; col++)
            {
                for (int row = 3; row >= 0; row--)
                {
                    down(row, col);
                }
            }
        }

        private static void down(int row, int col)
        {
            if (state[row, col] == 0)
            {
                //look up for non empty
                for (int i = row - 1; i >= 0 && state[row, col] == 0; i--)
                {
                    if (state[i, col] != 0)
                    {
                        state[row, col] = state[i, col];
                        state[i, col] = 0;
                    }
                }

            }
            //look up for merge.
            bool merge = false;
            for (int i = row - 1; i >= 0 && !merge; i--)
            {
                if (state[i, col] != 0)
                    merge = true;
                if (state[row, col] == state[i, col])
                {
                    state[row, col] *= 2;
                    state[i, col] = 0;
                }
            }
        }
    }
}
