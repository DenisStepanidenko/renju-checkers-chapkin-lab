using System;
using System.Collections.Generic;

namespace RenjuCheckers
{
    public class Output
    {
        /// <summary>
        /// метод, который показывает состояние поля ( то есть выводит матрицу )
        /// </summary>
        /// <param name="desk">Объект класса Desk</param>
        public static void ShowDesk(Desk desk)
        {
            Console.WriteLine();
            Console.WriteLine(desk.Show());
        }
        
        
        /// <summary>
        /// метод, который показывает роли игроков ( то есть цвет шашек)
        /// </summary>
        /// <param name="players">Словарь с игроками</param>
        public static void ShowRole(Dictionary<int, string> players)
        {
            Console.WriteLine(
                $"\n         Игрок {players[1]} - ЧЕРНЫЕ ({(CharactericticsOfTheGame) 1})\n\n         Игрок {players[2]} - БЕЛЫЕ ({(CharactericticsOfTheGame) 2})");
        }
        
        
        /// <summary>
        /// метод, который выводит сообщение о победителе
        /// </summary>
        /// <param name="currentMove">Текущий ход</param>
        /// <param name="players">Словарь с игроками</param>
        public static void ShowWinner(int currentMove, Dictionary<int, string> players)
        {
            Console.WriteLine(
                "------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(
                "{1}Ура, ура, у нас есть победитель!\n{1}Поздравляем игрока {2}!\n\r\n{3}████████╗██╗░░██╗░█████╗░███╗░░██╗██╗░░██╗{0}██╗░░░██╗░█████╗░██╗░░░██╗{0}███████╗░█████╗░██████╗░\r\n{3}╚══██╔══╝██║░░██║██╔══██╗████╗░██║██║░██╔╝{0}╚██╗░██╔╝██╔══██╗██║░░░██║{0}██╔════╝██╔══██╗██╔══██╗\r\n{3}░░░██║░░░███████║███████║██╔██╗██║█████═╝░{0}░╚████╔╝░██║░░██║██║░░░██║{0}█████╗░░██║░░██║██████╔╝\r\n{3}░░░██║░░░██╔══██║██╔══██║██║╚████║██╔═██╗░{0}░░╚██╔╝░░██║░░██║██║░░░██║{0}██╔══╝░░██║░░██║██╔══██╗\r\n{3}░░░██║░░░██║░░██║██║░░██║██║░╚███║██║░╚██╗{0}░░░██║░░░╚█████╔╝╚██████╔╝{0}██║░░░░░╚█████╔╝██║░░██║\r\n{3}░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚══╝╚═╝░░╚═╝{0}░░░╚═╝░░░░╚════╝░░╚═════╝░{0}╚═╝░░░░░░╚════╝░╚═╝░░╚═╝\r\n\r\n{3}██████╗░██╗░░░░░░█████╗░██╗░░░██╗██╗███╗░░██╗░██████╗░██╗\r\n{3}██╔══██╗██║░░░░░██╔══██╗╚██╗░██╔╝██║████╗░██║██╔════╝░██║\r\n{3}██████╔╝██║░░░░░███████║░╚████╔╝░██║██╔██╗██║██║░░██╗░██║\r\n{3}██╔═══╝░██║░░░░░██╔══██║░░╚██╔╝░░██║██║╚████║██║░░╚██╗╚═╝\r\n{3}██║░░░░░███████╗██║░░██║░░░██║░░░██║██║░╚███║╚██████╔╝██╗\r\n{3}╚═╝░░░░░╚══════╝╚═╝░░╚═╝░░░╚═╝░░░╚═╝╚═╝░░╚══╝░╚═════╝░╚═╝",
                "   ", "                                     ", players[currentMove], "          ");
        }
        
        
        /// <summary>
        /// метод, который выводит сообщение о том, что произошла ничья
        /// </summary>
        public static void ShowDraw()
        {
            Console.WriteLine(
                "\r\n{0}████████    ███              ██████  ███  ████████ \r\n{0}██░░░░░█   █░░█ ██████        █░░░█ ██░█  █░░░░█░█ \r\n{0} ██░░░░██ ██░░░█ █░░░█ ██████ █░░░███░░█ █░░░░██░█ \r\n{0}  ██░░░░█ █░░░░░██░░░██░░░░░░██░░░██░░░██░░░░░█░░█ \r\n{0}   █░░░░░█░░░░░░██░░░█░░████░░█░░░░░░░░░█░░░░██░░█ \r\n{0}   ██░░░░█░░░█░░░█░░░░░██  ██░░░░░░░░░░░░░░░░█░░░█ \r\n{0}    ██░░░░░░░██░░░░░░░░██  ██░░░░░░░██░░░░░░█░░░█ \r\n{0}     █░░░░░░█ ██░░░░█░░░████░░█░░░░███░░░░░░█░░█ \r\n{0}      █░░░░██  ██░░░███░░░░░░█░░░░██  █░░░░█░░█ \r\n{0}       █████    ██████ ██████ █████   ████████ \r\n{0}    █████████████████████████████████████████ \r\n{0}    ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░██░░██ \r\n{0}    ██░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█████ \r\n{0}    █████████████████████████████████████\r\n\r\n{1}{0}Игра завершилась НИЧЬЕЙ!",
                "                                     ", "           ");
        }
        
        
        /// <summary>
        /// метод, который выводит сообщение о том, что произошла ничья
        /// </summary>
        /// <param name="dao">Объект класса DAO</param>
        public static void ShowLeaderBord(DAO dao)
        {
            try
            {
                var leaderBord = dao.GetLeaderBord();
                Console.WriteLine(leaderBord);
            }
            catch (ExceptionWithLeaderBord e)
            {
                Console.WriteLine(e);
            }
            catch (Exception)
            {
                Console.WriteLine("Упс, произошла непридвиденная ошибка с загрузкой LeaderBord");
            }
        }
    }
}