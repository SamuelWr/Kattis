using System;
using System.Collections.Generic;

namespace cats
{
    class Program
    {
        static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine());
            while (cases > 0)
            {
                Case();
                cases--;
            }
        }

        private static void Case()
        {
            List<Edge> edges = new List<Edge>();
            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            int milkAvailable = int.Parse(ss[0]);
            int cats = int.Parse(ss[1]);


            for (int i = 0; i < (cats * (cats - 1)) / 2; i++)
            {
                s = Console.ReadLine();
                ss = s.Split(' ');
                edges.Add(new Edge(int.Parse(ss[0]), int.Parse(ss[1]), int.Parse(ss[2])));
            }

            int milkRequired = cats;
            milkRequired += Partition(cats, edges);

            if (milkRequired > milkAvailable)
                Console.WriteLine("no");
            else
                Console.WriteLine("yes");
            //Console.WriteLine($"Milk required: {milkRequired}\nMilk available: {milkAvailable}");
        }
        /// <summary>
        /// takes a number of partitions and edges between them
        /// returns minimum distance to connect them
        /// </summary>
        /// <param name="partitions">number of partitions</param>
        /// <param name="edges">list of (0 based) edges between partitions.</param>
        /// <returns></returns>
        private static int Partition(int partitions, List<Edge> edges)
        {
            if (partitions == 1)
                return 0;

            edges.Sort();
            int[] newPartitions = new int[partitions];
            partitions = 0;
            int Milkrequired = 0;

            //note, 0 is used to mean not yet partitioned.
            //partition numbering is therefore 1 based at the moment.
            for (int i = 0; i < edges.Count; i++)
            {
                Edge edge = edges[i];
                if (newPartitions[edge.first] == 0 && newPartitions[edge.second] == 0)
                {
                    partitions++;
                    Milkrequired += edge.length;
                    newPartitions[edge.first] = newPartitions[edge.second] = partitions;
                }
                else if (newPartitions[edge.first] == 0 || newPartitions[edge.second] == 0)
                {
                    Milkrequired += edge.length;
                    int part = newPartitions[edge.first] + newPartitions[edge.second];
                    newPartitions[edge.first] = newPartitions[edge.second] = part;
                }
                else
                {
                    //both already in different (local) partitions, ignore for now
                    //might be faster to handle here, but would require translation tables.
                }
            }

            //update edge targets
            //-1 because input is 0 based, but inside the algorithm it's implicitly converted to 1 based.
            foreach (var e in edges)
            {
                e.first = newPartitions[e.first] - 1;
                e.second = newPartitions[e.second] - 1;
            }
            //remove all edges that are now within a partition.
            edges.RemoveAll(e => e.first == e.second);

            Milkrequired += Partition(partitions, edges);

            return Milkrequired;
        }


    }
    internal class Edge : IComparable<Edge>
    {
        internal int first;
        internal int second;
        internal int length;
        public Edge(int first, int second, int length)
        {
            this.first = first;
            this.second = second;
            this.length = length;
        }

        public int CompareTo(Edge other)
        {
            return this.length.CompareTo(other.length);
        }
    }

}
