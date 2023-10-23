using System;
using System.Collections.Generic;

namespace RenjuCheckers
{
    public class RoleRandomizer
    {
        // метод, который с помощью random определяет цвет шашек игроков
        public static void GetRole(Dictionary<int, string> players, string name1, string name2)
        {
            var rand = new Random();
            var rNum = rand.Next(1, 3);
            switch (rNum)
            {
                case 1:
                {
                    players.Add(1, name1);
                    players.Add(2, name2);
                    break;
                }
                case 2:
                {
                    players.Add(1, name2);
                    players.Add(2, name1);
                    break;
                }
            }
        }
    }
}