using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RenjuCheckers
{
    public class DAO
    {
        private const string PathToSave = "C:/Users/stepa/RiderProjects/RenjuCheckers/RenjuCheckers/SaveGames.txt";
        private const string PathToLeaderBord = "C:/Users/stepa/RiderProjects/RenjuCheckers/RenjuCheckers/LeaderBord.txt";
        public static void LoadGame(Dictionary<int, string> players, ref int currentMove, Desk desk)
        {
            // в данном методе нам нужно распарсить файл txt в данные для нашей игры
            // сначала проверяем, есть ли в файле ( если он открылся) какие-то сохранения
            if (string.IsNullOrWhiteSpace(File.ReadAllText(PathToSave)))
            {
                throw new ExceptionWithSaveGame();
            }

            var lines = File.ReadAllLines(PathToSave);
            var matrix = new string[(int) CharactericticsOfTheGame.DeskSize, (int) CharactericticsOfTheGame.DeskSize];


            // сначала записываем матрицу
            for (var i = 0; i < (int) CharactericticsOfTheGame.DeskSize; i++)
            {
                var currentString = lines[i];
                for (var j = 0; j < (int) CharactericticsOfTheGame.DeskSize; j++)
                {
                    matrix[i, j] = Convert.ToString(currentString[j]);
                }
            }

            desk.SetMatrix(matrix);


            // читаем из файла имя первого игрока
            var name1 = lines[15].Split(' ');

            // записываем имя первого игрока (1 - тот кто чёрными)
            players.Add(Convert.ToInt16(name1[1]), name1[0]);

            // читаем из файла имя второго игрока
            var name2 = lines[16].Split(' ');

            // записываем имя второго игрока (2 - тот кто белыми)
            players.Add(Convert.ToInt16(name2[1]), name2[0]);

            // записываем currentMove
            currentMove = Convert.ToInt16(lines[17].Split(' ')[1]);

            //записываем filledCount
            int filledCount = Convert.ToInt16(lines[18].Split(' ')[1]);
            desk.SetFilledCount(filledCount);
        }

        // записываем игру в файл
        public static void SaveGame(Dictionary<int, string> players, int currentMove, Desk desk)
        {
            FileStream fs = new(PathToSave, FileMode.Create);
            StreamWriter sw = new(fs, Encoding.Default);
            foreach (var row in Utilities.GetDeskRows(desk.GetMatrix()))
            {
                sw.WriteLine(row);
            }

            sw.WriteLine($"{players[1]} {players.Where(x => x.Value == players[1]).FirstOrDefault().Key}");
            sw.WriteLine($"{players[2]} {players.Where(x => x.Value == players[2]).FirstOrDefault().Key}");

            sw.WriteLine($"CurrentMove {currentMove}");

            sw.WriteLine($"filledCount {desk.GetFilledCount()}");

            sw.Close();
            fs.Close();
        }

        public static string GetLeaderBord()
        {
            
            if (string.IsNullOrWhiteSpace(File.ReadAllText(PathToLeaderBord)))
            {
                throw new ExceptionWithLeaderBord();
            }
            var lines = File.ReadAllLines(PathToLeaderBord);
            var leaderBord = new StringBuilder();
            for (var i = 0; i < lines.Length; i++)
            {
                var current = lines[i].Split(' ');
                leaderBord.Append(current[0] + " ").Append("победы: " + current[1] + " ").Append("количество игр: " + current[2]).Append('\n');
            }
            return leaderBord.ToString();
            
        }

        public static void UpdateLeaderBord(string winnerName, string looserName, bool winnerExists)
        {
            
            if (string.IsNullOrWhiteSpace(File.ReadAllText(PathToLeaderBord)))
            {
                throw new ExceptionWithLeaderBord();
            }
            var lines = File.ReadAllLines(PathToLeaderBord);
            var allPlayers = new List<Player>();
            var isWinnerInLB = false;
            var isLoosingInLB = false;
            
            if (winnerExists)
            {
               
                for (var i = 0; i < lines.Length; i++)
                {
                    var currentPlayer = lines[i].Split(' ');
                    // 0 - имя
                    // 1 - победы
                    // 2 - всего игр
                    if (currentPlayer[0].Equals(winnerName))
                    {
                        isWinnerInLB = true;
                        allPlayers.Add(new Player(currentPlayer[0] , Convert.ToInt16(currentPlayer[1]) + 1 , Convert.ToInt16(currentPlayer[2]) + 1 ));
                    }
                    else if(currentPlayer[0].Equals(looserName))
                    {
                        isLoosingInLB = true;
                        allPlayers.Add(new Player(currentPlayer[0] , Convert.ToInt16(currentPlayer[1]), Convert.ToInt16(currentPlayer[2]) + 1 ));
                    }
                    else
                    {
                        allPlayers.Add(new Player(currentPlayer[0] , Convert.ToInt16(currentPlayer[1]), Convert.ToInt16(currentPlayer[2])));
                    }
                }





            }
        }
        
    }
}