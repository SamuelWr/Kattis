using System;
using System.Collections.Generic;

namespace moneymatters
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] ss = s.Split();
            int numPeople = int.Parse(ss[0]);
            int numFriendships = int.Parse(ss[1]);
            Person[] people = new Person[numPeople];
            int totalOwed = 0;

            //parse and create all people
            for (int i = 0; i < numPeople; i++)
            {
                short owed = short.Parse(Console.ReadLine());
                totalOwed += owed;
                people[i] = new Person(owed);
            }
            //Just make sure
            if (totalOwed != 0)
                throw new Exception("Sum of all owed amounts is not zero!");

            //Parse and create friendships
            for (int i = 0; i < numFriendships; i++)
            {
                string[] s0 = Console.ReadLine().Split();
                ushort pIdOne = ushort.Parse(s0[0]);
                ushort pIdTwo = ushort.Parse(s0[1]);
                people[pIdOne].AddFriend(people[pIdTwo]);
                people[pIdTwo].AddFriend(people[pIdOne]);
            }

            //main logic here.
            bool unresolvableDebtFound = false;
            for (ushort i = 0; i < people.Length && !unresolvableDebtFound; i++)
            {
                if (people[i].FloodFill() != 0)
                    unresolvableDebtFound = true;
            }
            if (unresolvableDebtFound)
                Console.WriteLine("IMPOSSIBLE");
            else
                Console.WriteLine("POSSIBLE");
        }
        class Person
        {
            //int Id == position in array
            internal short owed;
            internal List<Person> friends;
            internal bool hasBeenHandled;
            public Person(short owed)
            {
                this.owed = owed;
                friends = new List<Person>();
                hasBeenHandled = false;
            }
            public void AddFriend(Person friend)
            {
                friends.Add(friend);
            }

            internal int FloodFill()
            {
                if (hasBeenHandled)
                    return 0;
                hasBeenHandled = true;
                int owe = owed;
                foreach (var item in this.friends)
                {
                    owe += item.FloodFill();
                }
                return owe;
            }
        }
    }
}
