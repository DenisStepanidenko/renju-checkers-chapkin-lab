using System;
using System.Collections.Generic;

namespace RenjuCheckers
{
    public class Output
    {
        public static void ShowDesk(Desk desk)
        {
            Console.WriteLine();
            Console.WriteLine(desk.Show());
        }

        public static void ShowRole(Dictionary<int, string> players)
        {
            Console.WriteLine(
                $"\n         Игрок {players[1]} - ЧЕРНЫЕ ({(CharactericticsOfTheGame) 1})\n\n         Игрок {players[2]} - БЕЛЫЕ ({(CharactericticsOfTheGame) 2})");
        }

        public static void ShowWinner(int currentMove, Dictionary<int, string> players)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Ура, ура, в данной игре есть победитель!");
            Console.WriteLine("Поздравляем игрока с ником " + players[currentMove]);
        }

        public static void ShowDraw()
        {
            Console.WriteLine(
                "\r\n{0}████████    ███              ██████  ███  ████████ \r\n{0}██░░░░░█   █░░█ ██████        █░░░█ ██░█  █░░░░█░█ \r\n{0} ██░░░░██ ██░░░█ █░░░█ ██████ █░░░███░░█ █░░░░██░█ \r\n{0}  ██░░░░█ █░░░░░██░░░██░░░░░░██░░░██░░░██░░░░░█░░█ \r\n{0}   █░░░░░█░░░░░░██░░░█░░████░░█░░░░░░░░░█░░░░██░░█ \r\n{0}   ██░░░░█░░░█░░░█░░░░░██  ██░░░░░░░░░░░░░░░░█░░░█ \r\n{0}    ██░░░░░░░██░░░░░░░░██  ██░░░░░░░██░░░░░░█░░░█ \r\n{0}     █░░░░░░█ ██░░░░█░░░████░░█░░░░███░░░░░░█░░█ \r\n{0}      █░░░░██  ██░░░███░░░░░░█░░░░██  █░░░░█░░█ \r\n{0}       █████    ██████ ██████ █████   ████████ \r\n{0}    █████████████████████████████████████████ \r\n{0}    ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░░██ \r\n{0}    ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█████ \r\n{0}    █████████████████████████████████████\r\n\r\n{1}{0}Игра завершилась НИЧЬЕЙ!",
                "                                     ", "           ");
        }
    }
}