using System;
using System.Collections.Generic;

namespace RenjuCheckers
{
    public class Output
    {
        // метод, который показывает состояние поля ( то есть выводит матрицу )
        public static void ShowDesk(Desk desk)
        {
            Console.WriteLine();
            Console.WriteLine(desk.Show());
        }
        
        // метод, который показывает роли игроков ( то есть цвет шашек)
        public static void ShowRole(Dictionary<int, string> players)
        {
            Console.WriteLine(
                $"\n         Игрок {players[1]} - ЧЕРНЫЕ ({(CharactericticsOfTheGame) 1})\n\n         Игрок {players[2]} - БЕЛЫЕ ({(CharactericticsOfTheGame) 2})");
        }
    
        // метод, который выводит сообщение о победителе
        public static void ShowWinner(int currentMove, Dictionary<int, string> players)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Ура, ура, в данной игре есть победитель!");
            Console.WriteLine("Поздравляем игрока с ником " + players[currentMove]);
        }
        
        //метод, который выводит сообщение о том, что произошла ничья
        public static void ShowDraw()
        {
            Console.WriteLine(
                "\r\n{0}████████    ███              ██████  ███  ████████ \r\n{0}██░░░░░█   █░░█ ██████        █░░░█ ██░█  █░░░░█░█ \r\n{0} ██░░░░██ ██░░░█ █░░░█ ██████ █░░░███░░█ █░░░░██░█ \r\n{0}  ██░░░░█ █░░░░░██░░░██░░░░░░██░░░██░░░██░░░░░█░░█ \r\n{0}   █░░░░░█░░░░░░██░░░█░░████░░█░░░░░░░░░█░░░░██░░█ \r\n{0}   ██░░░░█░░░█░░░█░░░░░██  ██░░░░░░░░░░░░░░░░█░░░█ \r\n{0}    ██░░░░░░░██░░░░░░░░██  ██░░░░░░░██░░░░░░█░░░█ \r\n{0}     █░░░░░░█ ██░░░░█░░░████░░█░░░░███░░░░░░█░░█ \r\n{0}      █░░░░██  ██░░░███░░░░░░█░░░░██  █░░░░█░░█ \r\n{0}       █████    ██████ ██████ █████   ████████ \r\n{0}    █████████████████████████████████████████ \r\n{0}    ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░░██ \r\n{0}    ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█████ \r\n{0}    █████████████████████████████████████\r\n\r\n{1}{0}Игра завершилась НИЧЬЕЙ!",
                "                                     ", "           ");
        }
    }
}