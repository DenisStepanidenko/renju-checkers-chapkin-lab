using System;
using System.Collections.Generic;

namespace RenjuCheckers
{
    public class RoleRandomizer
    {
        public static void GetRole(Dictionary<int, string> players, string name1, string name2)
        {
            var rand = new Random();
            var rNum = rand.Next(1, 3);
            if (rNum == 1)
            {
                players.Add(1, name1);
                players.Add(2, name2);
            }
            else if (rNum == 2)
            {
                players.Add(1, name2);
                players.Add(2, name1);
            }
        }
    }
}