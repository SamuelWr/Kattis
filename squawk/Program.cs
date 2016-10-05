using System;
using System.Collections.Generic;

namespace squawk
{
    class Program
    {
        public const int Max_Time = 9;
        static void Main(string[] args)
        {
            int numUsers;
            int numLinks;
            int patientZero;
            int endTime;
            string s = Console.ReadLine();
            string[] ss = s.Split(' ');
            numUsers = int.Parse(ss[0]);
            numLinks = int.Parse(ss[1]);
            patientZero = int.Parse(ss[2]);
            endTime = int.Parse(ss[3]);

            User[] users = new User[numUsers];
            for (int i = 0; i < numUsers; i++)
            {
                users[i] = new User(i);
            }
            for (int i = 0; i < numLinks; i++)
            {
                s = Console.ReadLine();
                ss = s.Split(' ');
                User x = users[int.Parse(ss[0])];
                User y = users[int.Parse(ss[1])];
                x.AddFriend(y);
                y.AddFriend(x);
            }
            //initial infection
            users[patientZero].squawksAtTime[0] = 1;
            for (int i = 0; i < endTime; i++)
            {
                foreach (var usr in users)
                {
                    usr.Act(i);
                }
            }
            ulong squawksAtEnd = 0;
            foreach (var usr in users)
            {
                squawksAtEnd += usr.squawksAtTime[endTime];
            }
            Console.WriteLine(squawksAtEnd);
        }
    }
    class User
    {
        public int id;
        List<User> friends = new List<User>();
        public ulong[] squawksAtTime = new ulong[Program.Max_Time + 1];
        bool[] hasActedAtTime = new bool[Program.Max_Time + 1];
        public User(int id)
        {
            this.id = id;
        }
        public void AddFriend(User f)
        {
            friends.Add(f);
        }
        public void Act(int time)
        {
            if (hasActedAtTime[time])
            {
                return;
            }
            hasActedAtTime[time] = true;
            foreach (var friend in friends)
            {
                friend.squawksAtTime[time + 1] += squawksAtTime[time];
                //friend.Act(time);
            }
        }
    }
}
