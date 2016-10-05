using System;
using System.Collections.Generic;

namespace _4thought
{
    class Program
    {
        static Dictionary<int, string> table;
        static void Main(string[] args)
        {
            table = new Dictionary<int, string>(64);
            table.Add(16, "4 + 4 + 4 + 4 = 16");
            table.Add(8, "4 + 4 + 4 - 4 = 8");
            table.Add(24, "4 + 4 + 4 * 4 = 24");
            table.Add(9, "4 + 4 + 4 / 4 = 9");
            table.Add(0, "4 + 4 - 4 - 4 = 0");
            table.Add(-8, "4 + 4 - 4 * 4 = -8");
            table.Add(7, "4 + 4 - 4 / 4 = 7");
            table.Add(68, "4 + 4 * 4 * 4 = 68");
            table.Add(1, "4 + 4 / 4 - 4 = 1");
            table.Add(4, "4 + 4 / 4 / 4 = 4");
            table.Add(-16, "4 - 4 - 4 * 4 = -16");
            table.Add(-1, "4 - 4 - 4 / 4 = -1");
            table.Add(-60, "4 - 4 * 4 * 4 = -60");
            table.Add(32, "4 * 4 + 4 * 4 = 32");
            table.Add(17, "4 * 4 + 4 / 4 = 17");
            table.Add(15, "4 * 4 - 4 / 4 = 15");
            table.Add(60, "4 * 4 * 4 - 4 = 60");
            table.Add(256, "4 * 4 * 4 * 4 = 256");
            table.Add(2, "4 / 4 + 4 / 4 = 2");
            table.Add(-7, "4 / 4 - 4 - 4 = -7");
            table.Add(-15, "4 / 4 - 4 * 4 = -15");
            table.Add(-4, "4 / 4 / 4 - 4 = -4");

            int numQueries = int.Parse(Console.ReadLine());
            for (int i = 0; i < numQueries; i++)
            {
                int query = int.Parse(Console.ReadLine());
                if (table.ContainsKey(query))
                    Console.WriteLine(table[query]);
                else
                    Console.WriteLine("no solution");


            }

            //string symbol = "+-*/";
            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        for (int k = 0; k < 4; k++)
            //        {
            //            string s="";
            //            s += $"if (!table.ContainsKey(4{symbol[i]}4{symbol[j]}4{symbol[k]}4))";
            //            s += Environment.NewLine;
            //            s += $"table.Add(4 {symbol[i]} 4 {symbol[j]} 4 {symbol[k]} 4 ,\"4 {symbol[i]} 4 {symbol[j]} 4 {symbol[k]} 4 = \" + (4{symbol[i]}4{symbol[j]}4{symbol[k]}4 ));";
            //            Console.WriteLine(s);

            //        }
            //    }
            //}


            //if (!table.ContainsKey(4 + 4 + 4 + 4))
            //    table.Add(4 + 4 + 4 + 4, "4 + 4 + 4 + 4 = " + (4 + 4 + 4 + 4));
            //if (!table.ContainsKey(4 + 4 + 4 - 4))
            //    table.Add(4 + 4 + 4 - 4, "4 + 4 + 4 - 4 = " + (4 + 4 + 4 - 4));
            //if (!table.ContainsKey(4 + 4 + 4 * 4))
            //    table.Add(4 + 4 + 4 * 4, "4 + 4 + 4 * 4 = " + (4 + 4 + 4 * 4));
            //if (!table.ContainsKey(4 + 4 + 4 / 4))
            //    table.Add(4 + 4 + 4 / 4, "4 + 4 + 4 / 4 = " + (4 + 4 + 4 / 4));
            //if (!table.ContainsKey(4 + 4 - 4 + 4))
            //    table.Add(4 + 4 - 4 + 4, "4 + 4 - 4 + 4 = " + (4 + 4 - 4 + 4));
            //if (!table.ContainsKey(4 + 4 - 4 - 4))
            //    table.Add(4 + 4 - 4 - 4, "4 + 4 - 4 - 4 = " + (4 + 4 - 4 - 4));
            //if (!table.ContainsKey(4 + 4 - 4 * 4))
            //    table.Add(4 + 4 - 4 * 4, "4 + 4 - 4 * 4 = " + (4 + 4 - 4 * 4));
            //if (!table.ContainsKey(4 + 4 - 4 / 4))
            //    table.Add(4 + 4 - 4 / 4, "4 + 4 - 4 / 4 = " + (4 + 4 - 4 / 4));
            //if (!table.ContainsKey(4 + 4 * 4 + 4))
            //    table.Add(4 + 4 * 4 + 4, "4 + 4 * 4 + 4 = " + (4 + 4 * 4 + 4));
            //if (!table.ContainsKey(4 + 4 * 4 - 4))
            //    table.Add(4 + 4 * 4 - 4, "4 + 4 * 4 - 4 = " + (4 + 4 * 4 - 4));
            //if (!table.ContainsKey(4 + 4 * 4 * 4))
            //    table.Add(4 + 4 * 4 * 4, "4 + 4 * 4 * 4 = " + (4 + 4 * 4 * 4));
            //if (!table.ContainsKey(4 + 4 * 4 / 4))
            //    table.Add(4 + 4 * 4 / 4, "4 + 4 * 4 / 4 = " + (4 + 4 * 4 / 4));
            //if (!table.ContainsKey(4 + 4 / 4 + 4))
            //    table.Add(4 + 4 / 4 + 4, "4 + 4 / 4 + 4 = " + (4 + 4 / 4 + 4));
            //if (!table.ContainsKey(4 + 4 / 4 - 4))
            //    table.Add(4 + 4 / 4 - 4, "4 + 4 / 4 - 4 = " + (4 + 4 / 4 - 4));
            //if (!table.ContainsKey(4 + 4 / 4 * 4))
            //    table.Add(4 + 4 / 4 * 4, "4 + 4 / 4 * 4 = " + (4 + 4 / 4 * 4));
            //if (!table.ContainsKey(4 + 4 / 4 / 4))
            //    table.Add(4 + 4 / 4 / 4, "4 + 4 / 4 / 4 = " + (4 + 4 / 4 / 4));
            //if (!table.ContainsKey(4 - 4 + 4 + 4))
            //    table.Add(4 - 4 + 4 + 4, "4 - 4 + 4 + 4 = " + (4 - 4 + 4 + 4));
            //if (!table.ContainsKey(4 - 4 + 4 - 4))
            //    table.Add(4 - 4 + 4 - 4, "4 - 4 + 4 - 4 = " + (4 - 4 + 4 - 4));
            //if (!table.ContainsKey(4 - 4 + 4 * 4))
            //    table.Add(4 - 4 + 4 * 4, "4 - 4 + 4 * 4 = " + (4 - 4 + 4 * 4));
            //if (!table.ContainsKey(4 - 4 + 4 / 4))
            //    table.Add(4 - 4 + 4 / 4, "4 - 4 + 4 / 4 = " + (4 - 4 + 4 / 4));
            //if (!table.ContainsKey(4 - 4 - 4 + 4))
            //    table.Add(4 - 4 - 4 + 4, "4 - 4 - 4 + 4 = " + (4 - 4 - 4 + 4));
            //if (!table.ContainsKey(4 - 4 - 4 - 4))
            //    table.Add(4 - 4 - 4 - 4, "4 - 4 - 4 - 4 = " + (4 - 4 - 4 - 4));
            //if (!table.ContainsKey(4 - 4 - 4 * 4))
            //    table.Add(4 - 4 - 4 * 4, "4 - 4 - 4 * 4 = " + (4 - 4 - 4 * 4));
            //if (!table.ContainsKey(4 - 4 - 4 / 4))
            //    table.Add(4 - 4 - 4 / 4, "4 - 4 - 4 / 4 = " + (4 - 4 - 4 / 4));
            //if (!table.ContainsKey(4 - 4 * 4 + 4))
            //    table.Add(4 - 4 * 4 + 4, "4 - 4 * 4 + 4 = " + (4 - 4 * 4 + 4));
            //if (!table.ContainsKey(4 - 4 * 4 - 4))
            //    table.Add(4 - 4 * 4 - 4, "4 - 4 * 4 - 4 = " + (4 - 4 * 4 - 4));
            //if (!table.ContainsKey(4 - 4 * 4 * 4))
            //    table.Add(4 - 4 * 4 * 4, "4 - 4 * 4 * 4 = " + (4 - 4 * 4 * 4));
            //if (!table.ContainsKey(4 - 4 * 4 / 4))
            //    table.Add(4 - 4 * 4 / 4, "4 - 4 * 4 / 4 = " + (4 - 4 * 4 / 4));
            //if (!table.ContainsKey(4 - 4 / 4 + 4))
            //    table.Add(4 - 4 / 4 + 4, "4 - 4 / 4 + 4 = " + (4 - 4 / 4 + 4));
            //if (!table.ContainsKey(4 - 4 / 4 - 4))
            //    table.Add(4 - 4 / 4 - 4, "4 - 4 / 4 - 4 = " + (4 - 4 / 4 - 4));
            //if (!table.ContainsKey(4 - 4 / 4 * 4))
            //    table.Add(4 - 4 / 4 * 4, "4 - 4 / 4 * 4 = " + (4 - 4 / 4 * 4));
            //if (!table.ContainsKey(4 - 4 / 4 / 4))
            //    table.Add(4 - 4 / 4 / 4, "4 - 4 / 4 / 4 = " + (4 - 4 / 4 / 4));
            //if (!table.ContainsKey(4 * 4 + 4 + 4))
            //    table.Add(4 * 4 + 4 + 4, "4 * 4 + 4 + 4 = " + (4 * 4 + 4 + 4));
            //if (!table.ContainsKey(4 * 4 + 4 - 4))
            //    table.Add(4 * 4 + 4 - 4, "4 * 4 + 4 - 4 = " + (4 * 4 + 4 - 4));
            //if (!table.ContainsKey(4 * 4 + 4 * 4))
            //    table.Add(4 * 4 + 4 * 4, "4 * 4 + 4 * 4 = " + (4 * 4 + 4 * 4));
            //if (!table.ContainsKey(4 * 4 + 4 / 4))
            //    table.Add(4 * 4 + 4 / 4, "4 * 4 + 4 / 4 = " + (4 * 4 + 4 / 4));
            //if (!table.ContainsKey(4 * 4 - 4 + 4))
            //    table.Add(4 * 4 - 4 + 4, "4 * 4 - 4 + 4 = " + (4 * 4 - 4 + 4));
            //if (!table.ContainsKey(4 * 4 - 4 - 4))
            //    table.Add(4 * 4 - 4 - 4, "4 * 4 - 4 - 4 = " + (4 * 4 - 4 - 4));
            //if (!table.ContainsKey(4 * 4 - 4 * 4))
            //    table.Add(4 * 4 - 4 * 4, "4 * 4 - 4 * 4 = " + (4 * 4 - 4 * 4));
            //if (!table.ContainsKey(4 * 4 - 4 / 4))
            //    table.Add(4 * 4 - 4 / 4, "4 * 4 - 4 / 4 = " + (4 * 4 - 4 / 4));
            //if (!table.ContainsKey(4 * 4 * 4 + 4))
            //    table.Add(4 * 4 * 4 + 4, "4 * 4 * 4 + 4 = " + (4 * 4 * 4 + 4));
            //if (!table.ContainsKey(4 * 4 * 4 - 4))
            //    table.Add(4 * 4 * 4 - 4, "4 * 4 * 4 - 4 = " + (4 * 4 * 4 - 4));
            //if (!table.ContainsKey(4 * 4 * 4 * 4))
            //    table.Add(4 * 4 * 4 * 4, "4 * 4 * 4 * 4 = " + (4 * 4 * 4 * 4));
            //if (!table.ContainsKey(4 * 4 * 4 / 4))
            //    table.Add(4 * 4 * 4 / 4, "4 * 4 * 4 / 4 = " + (4 * 4 * 4 / 4));
            //if (!table.ContainsKey(4 * 4 / 4 + 4))
            //    table.Add(4 * 4 / 4 + 4, "4 * 4 / 4 + 4 = " + (4 * 4 / 4 + 4));
            //if (!table.ContainsKey(4 * 4 / 4 - 4))
            //    table.Add(4 * 4 / 4 - 4, "4 * 4 / 4 - 4 = " + (4 * 4 / 4 - 4));
            //if (!table.ContainsKey(4 * 4 / 4 * 4))
            //    table.Add(4 * 4 / 4 * 4, "4 * 4 / 4 * 4 = " + (4 * 4 / 4 * 4));
            //if (!table.ContainsKey(4 * 4 / 4 / 4))
            //    table.Add(4 * 4 / 4 / 4, "4 * 4 / 4 / 4 = " + (4 * 4 / 4 / 4));
            //if (!table.ContainsKey(4 / 4 + 4 + 4))
            //    table.Add(4 / 4 + 4 + 4, "4 / 4 + 4 + 4 = " + (4 / 4 + 4 + 4));
            //if (!table.ContainsKey(4 / 4 + 4 - 4))
            //    table.Add(4 / 4 + 4 - 4, "4 / 4 + 4 - 4 = " + (4 / 4 + 4 - 4));
            //if (!table.ContainsKey(4 / 4 + 4 * 4))
            //    table.Add(4 / 4 + 4 * 4, "4 / 4 + 4 * 4 = " + (4 / 4 + 4 * 4));
            //if (!table.ContainsKey(4 / 4 + 4 / 4))
            //    table.Add(4 / 4 + 4 / 4, "4 / 4 + 4 / 4 = " + (4 / 4 + 4 / 4));
            //if (!table.ContainsKey(4 / 4 - 4 + 4))
            //    table.Add(4 / 4 - 4 + 4, "4 / 4 - 4 + 4 = " + (4 / 4 - 4 + 4));
            //if (!table.ContainsKey(4 / 4 - 4 - 4))
            //    table.Add(4 / 4 - 4 - 4, "4 / 4 - 4 - 4 = " + (4 / 4 - 4 - 4));
            //if (!table.ContainsKey(4 / 4 - 4 * 4))
            //    table.Add(4 / 4 - 4 * 4, "4 / 4 - 4 * 4 = " + (4 / 4 - 4 * 4));
            //if (!table.ContainsKey(4 / 4 - 4 / 4))
            //    table.Add(4 / 4 - 4 / 4, "4 / 4 - 4 / 4 = " + (4 / 4 - 4 / 4));
            //if (!table.ContainsKey(4 / 4 * 4 + 4))
            //    table.Add(4 / 4 * 4 + 4, "4 / 4 * 4 + 4 = " + (4 / 4 * 4 + 4));
            //if (!table.ContainsKey(4 / 4 * 4 - 4))
            //    table.Add(4 / 4 * 4 - 4, "4 / 4 * 4 - 4 = " + (4 / 4 * 4 - 4));
            //if (!table.ContainsKey(4 / 4 * 4 * 4))
            //    table.Add(4 / 4 * 4 * 4, "4 / 4 * 4 * 4 = " + (4 / 4 * 4 * 4));
            //if (!table.ContainsKey(4 / 4 * 4 / 4))
            //    table.Add(4 / 4 * 4 / 4, "4 / 4 * 4 / 4 = " + (4 / 4 * 4 / 4));
            //if (!table.ContainsKey(4 / 4 / 4 + 4))
            //    table.Add(4 / 4 / 4 + 4, "4 / 4 / 4 + 4 = " + (4 / 4 / 4 + 4));
            //if (!table.ContainsKey(4 / 4 / 4 - 4))
            //    table.Add(4 / 4 / 4 - 4, "4 / 4 / 4 - 4 = " + (4 / 4 / 4 - 4));
            //if (!table.ContainsKey(4 / 4 / 4 * 4))
            //    table.Add(4 / 4 / 4 * 4, "4 / 4 / 4 * 4 = " + (4 / 4 / 4 * 4));
            //if (!table.ContainsKey(4 / 4 / 4 / 4))
            //    table.Add(4 / 4 / 4 / 4, "4 / 4 / 4 / 4 = " + (4 / 4 / 4 / 4));

            //foreach (var item in table)
            //{
            //    Console.WriteLine($"table.Add({item.Key},  \"{item.Value}\");");
            //}
        }
    }
}
