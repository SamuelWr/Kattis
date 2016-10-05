using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestcompression
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            long numfiles = long.Parse(input[0]);
            int bytes = int.Parse(input[1]);
            //Console.WriteLine("numfiles: " + numfiles);
            //Console.WriteLine("bytes: " + bytes);
            long maxFiles = (1L << (bytes + 1)) - 1;
            //Console.WriteLine("maxfiles: " + maxFiles);
            if (maxFiles >= numfiles)
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
        }
    }
}
