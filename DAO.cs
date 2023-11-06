using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace RenjuCheckers
{
    public class DAO
    {
        public string PathToSave { get; }
        public string PathToLeaderBord { get; }


        public DAO(string path)
        {
            PathToSave = path + "\\SaveGames.txt";
            PathToLeaderBord = path + "\\LeaderBoard.txt";
        }
        
        
        /// <summary>
        /// Метод загружает игру из БД
        /// </summary>
        /// <param name="players">Словарь с игроками</param>
        /// <param name="currentMove">Текущий ход</param>
        /// <param name="desk">Объект класса Desk</param>
        /// <exception cref="ExceptionWithSaveGame">Пробрасываем исключение в Input чтобы там пользователь повторил ввод</exception>
        public void LoadGame(Dictionary<int, string> players, ref int currentMove, Desk desk)
        {
            // сначала проверим - есть ли файл с сохранениями
            // сначала проверяем - есть ли такой файл, если нет - то создаём по указанному адресу
            if (!File.Exists(PathToSave))
            {
                File.Create(PathToSave).Close();
            }

            // в данном методе нам нужно распарсить файл txt в данные для нашей игры
            // сначала проверяем, есть ли в файле ( если он открылся) какие-то сохранения
            if (string.IsNullOrWhiteSpace(File.ReadAllText(PathToSave)))
            {
                throw new ExceptionWithSaveGame();
            }


            var lines = File.ReadAllLines(PathToSave);
            var matrix = new string[(int) CharactericticsOfTheGame.DeskSize,
                (int) CharactericticsOfTheGame.DeskSize];


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
        
        
        
        /// <summary>
        /// Метод, который сохраняет текущее состояние игры
        /// </summary>
        /// <param name="players">Словарь с игроками</param>
        /// <param name="currentMove">Текущий ход</param>
        /// <param name="desk">Объект класса Desk</param>
        public void SaveGame(Dictionary<int, string> players, int currentMove, Desk desk)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream(PathToSave, FileMode.Create);
                sw = new StreamWriter(fs, Encoding.Unicode);
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
            catch
            {
                Console.WriteLine("Произошла непредвиденная ошибка при сохранении игры");
            }
            finally
            {
                // всё равно нужно закрыть все потоки
                if (!(sw == null))
                {
                    sw.Close();
                }

                if (!(fs == null))
                {
                    fs.Close();
                }
            }
        }
        
        /// <summary>
        /// Данный метод загружает LeaderBoard из БД
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ExceptionWithLeaderBord">Выбрасываем исключение в Output если файл пустой</exception>
        public string GetLeaderBord()
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
                leaderBord.Append(current[0] + " ").Append("победы: " + current[1] + " ")
                    .Append("количество игр: " + current[2]).Append('\n');
            }

            return leaderBord.ToString();
        }

        /// <summary>
        /// Данный метод нужен для обновления LeaderBoard при чье-то победе или ничьи
        /// winnerName - имя победителя
        /// looserName - имя проигравшего
        /// winnerExists - параметр, который отвечает за конкретный тип обовления LeaderBoard - либо ничья(false), либо победа(true)
        /// </summary>
        /// <param name="winnerName"></param>
        /// <param name="looserName"></param>
        /// <param name="winnerExists"></param>
        public void UpdateLeaderBord(string winnerName, string looserName, bool winnerExists)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                // сначала проверяем - есть ли такой файл, если нет - то создаём по указанному адресу
                if (!File.Exists(PathToLeaderBord))
                {
                    File.Create(PathToLeaderBord).Close();
                }

                var lines = File.ReadAllLines(PathToLeaderBord);
                fs = new FileStream(PathToLeaderBord, FileMode.Create);
                sw = new StreamWriter(fs, Encoding.Unicode);
                var allPlayers = new List<Player>();
                var isWinnerInLb = true;
                var isLoosingInLb = true;
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
                            isWinnerInLb = false;
                            allPlayers.Add(new Player(currentPlayer[0], Convert.ToInt16(currentPlayer[1]) + 1,
                                Convert.ToInt16(currentPlayer[2]) + 1));
                        }
                        else if (currentPlayer[0].Equals(looserName))
                        {
                            isLoosingInLb = false;
                            allPlayers.Add(new Player(currentPlayer[0], Convert.ToInt16(currentPlayer[1]),
                                Convert.ToInt16(currentPlayer[2]) + 1));
                        }
                        else
                        {
                            allPlayers.Add(new Player(currentPlayer[0], Convert.ToInt16(currentPlayer[1]),
                                Convert.ToInt16(currentPlayer[2])));
                        }
                    }

                    // проверяем, был ли победитель среди считанных игроков
                    if (isWinnerInLb)
                    {
                        // значит победителя нет в leaderBord
                        allPlayers.Add(new Player(winnerName, 1, 1));
                    }

                    // проверяем был ли проигравший среди считанных игроков
                    if (isLoosingInLb)
                    {
                        allPlayers.Add(new Player(looserName, 0, 1));
                    }


                    allPlayers.Sort(); // сортируем по количество побед, это возможно сделать, так как Player наследует IComparable


                    // теперь записываем обратно в файлик новый отсортированный leaderBord


                    foreach (var player in allPlayers)
                    {
                        sw.WriteLine(player.ToString());
                    }
                }
                else
                {
                    // сюда мы попадаем, если оба игрока сыграли в ничью
                    for (var i = 0; i < lines.Length; i++)
                    {
                        var currentPlayer = lines[i].Split(' ');
                        // 0 - имя
                        // 1 - победы
                        // 2 - всего игр
                        if (currentPlayer[0].Equals(winnerName))
                        {
                            isWinnerInLb = false;
                            allPlayers.Add(new Player(winnerName, Convert.ToInt16(currentPlayer[1]),
                                Convert.ToInt16(currentPlayer[2]) + 1));
                        }
                        else if (currentPlayer[0].Equals(looserName))
                        {
                            isLoosingInLb = false;
                            allPlayers.Add(new Player(looserName, Convert.ToInt16(currentPlayer[1]),
                                Convert.ToInt16(currentPlayer[2]) + 1));
                        }
                        else
                        {
                            allPlayers.Add(new Player(looserName, Convert.ToInt16(currentPlayer[1]),
                                Convert.ToInt16(currentPlayer[2])));
                        }
                    }

                    // проверяем, был ли победитель среди считанных игроков
                    if (isWinnerInLb)
                    {
                        // значит победителя нет в leaderBord
                        allPlayers.Add(new Player(winnerName, 0, 1));
                    }

                    // проверяем был ли проигравший среди считанных игроков
                    if (isLoosingInLb)
                    {
                        allPlayers.Add(new Player(looserName, 0, 1));
                    }

                    foreach (var player in allPlayers)
                    {
                        sw.WriteLine(player.ToString());
                    }
                }
            }
            catch
            {
                Console.WriteLine("Произошла непредвиденная ошибка при обновлении LeaderBoard");
            }
            finally
            {
                // всё равно нужно закрыть все потоки
                if (!(sw == null))
                {
                    sw.Close();
                }

                if (!(fs == null))
                {
                    fs.Close();
                }
            }
        }
    }
}