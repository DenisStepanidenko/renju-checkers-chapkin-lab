using System;
using System.Collections.Generic;

namespace RenjuCheckers
{
    public class Output
    {
        public static void ShowDesk(Desk desk)
        {
            Console.WriteLine("Текущее состояние игры");
            Console.WriteLine();
            Console.WriteLine(desk.Show());
        }
        public static void ShowRole(Dictionary<int, string> players)
        {
            Console.WriteLine($"\n         Игрок {players[1]} - ЧЕРНЫЕ ({(CharactericticsOfTheGame)1})\n\n         Игрок {players[2]} - БЕЛЫЕ ({(CharactericticsOfTheGame)2})");
        }
    }
}