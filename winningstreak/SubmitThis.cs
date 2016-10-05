//using System;
//using System.IO;

//namespace winningstreak
//{
//    class SubmitThis
//    {
//        static void Main(string[] args)
//        {
//            var scanner = new Scanner();
//            var writer = new BufferedStdoutWriter();
//            while (scanner.HasNext())
//            {
//                int numMatches = scanner.NextInt();
//                double pWin = scanner.NextDouble();

//                var average = ComputeAverageStreak(numMatches, pWin);
//                writer.WriteLine(average);
//            }
//            writer.Flush();
//        }

//        static double[] powerCache;
//        static double pWin;
//        public static double ComputeAverageStreak(int numMatches, double pWin)
//        {
//            powerCache = new double[numMatches + 1];
//            SubmitThis.pWin = pWin;

//            var average = 0d;
//            /*
//             * Sum(n=0 => n=k)n*P(Longest=n) == Sum(n=0 => n=k)P(longest >= n)
//             */
//            for (int streakLength = 1; streakLength <= numMatches; streakLength++)
//            {
//                average += ProbStreakAtLeast(streakLength, numMatches);
//            }
//            return average;
//        }
//        private static double ProbStreakAtLeast(int streakLength, int numMatches)
//        {
//            double[] localCache = new double[numMatches + 1];
//            localCache[streakLength] = cachedPower(streakLength);
//            for (int i = streakLength + 1; i < localCache.Length; i++)
//            {
//                //streak length is minimum 1, so i-1 is never outside array bounds.

//                double previousProb = localCache[i - 1];

//                double probLower = i - (streakLength + 1) >= 0 ? localCache[i - (streakLength + 1)] : 0;

//                double newProb = (1 - probLower)//probability of not having a streak in first matches
//                            * (1 - pWin) * cachedPower(streakLength);


//                localCache[i] = previousProb + newProb;
//            }
//            return localCache[numMatches];
//        }

//        private static double cachedPower(int exponent)
//        {
//            if (powerCache[exponent] != 0)
//                return powerCache[exponent];
//            powerCache[exponent] = Math.Pow(pWin, exponent);
//            return powerCache[exponent];
//        }

//    }
//    public class NoMoreTokensException : Exception
//    {
//    }

//    public class Tokenizer
//    {
//        string[] tokens = new string[0];
//        private int pos;
//        StreamReader reader;

//        public Tokenizer(Stream inStream)
//        {
//            var bs = new BufferedStream(inStream);
//            reader = new StreamReader(bs);
//        }

//        public Tokenizer() : this(Console.OpenStandardInput())
//        {
//            // Nothing more to do
//        }

//        private string PeekNext()
//        {
//            if (pos < 0)
//                // pos < 0 indicates that there are no more tokens
//                return null;
//            if (pos < tokens.Length)
//            {
//                if (tokens[pos].Length == 0)
//                {
//                    ++pos;
//                    return PeekNext();
//                }
//                return tokens[pos];
//            }
//            string line = reader.ReadLine();
//            if (line == null)
//            {
//                // There is no more data to read
//                pos = -1;
//                return null;
//            }
//            // Split the line that was read on white space characters
//            tokens = line.Split(null);
//            pos = 0;
//            return PeekNext();
//        }

//        public bool HasNext()
//        {
//            return (PeekNext() != null);
//        }

//        public string Next()
//        {
//            string next = PeekNext();
//            if (next == null)
//                throw new NoMoreTokensException();
//            ++pos;
//            return next;
//        }
//    }


//    public class Scanner : Tokenizer
//    {

//        public int NextInt()
//        {
//            return int.Parse(Next());
//        }

//        public long NextLong()
//        {
//            return long.Parse(Next());
//        }

//        public float NextFloat()
//        {
//            return float.Parse(Next());
//        }

//        public double NextDouble()
//        {
//            return double.Parse(Next());
//        }
//    }


//    public class BufferedStdoutWriter : StreamWriter
//    {
//        public BufferedStdoutWriter() : base(new BufferedStream(Console.OpenStandardOutput()))
//        {
//        }
//    }
//}