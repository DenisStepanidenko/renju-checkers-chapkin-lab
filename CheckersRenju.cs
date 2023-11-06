using System.Collections.Generic;


namespace RenjuCheckers
{
    // основной класс, где будет описана последовательность действий в игре
    public class CheckersRenju : Game
    {
        // ключ 1 - игрок, который играет чёрными фишками ( X )
        // ключ 2 - игрок, который играет белыми фишками ( Y )
        private Dictionary<int, string> _players = new Dictionary<int, string>();
        public const int DeskSize = (int) CharactericticsOfTheGame.DeskSize; // размер доски

        public const int WinningRowSize = (int) CharactericticsOfTheGame.WinningRowSize; // количество подряд идущих фишек для победы

        private Desk _desk = new Desk(DeskSize); // само поле для игры
        public int CurrentMove = 1; // текущий ход игрока, если 1 - чёрные, 2 - белые
        private DAO _dao; // объект класса DAO (нужен для чтения и записи в БД)

        // конструктор, создаём в нём сразу объект класса DAO с путём до текущего каталога
        public CheckersRenju(string path)
        {
            _dao = new DAO(path);
        }

        // основной класс, где будет происходть действия в игре
        public override void Start()
        {
            // начинаем игру с выбора пользователем начала - либо загрузить уже создануюю игру либо начать новую
            Input.LoadOrInitial(_players, ref CurrentMove, _desk, _dao);

            // код действий самой логики игры
            while (true)
            {
                // выводим текущее расположение доски
                Output.ShowDesk(_desk);

                // инициализация текущих координат
                int x, y;

                // получение хода текущего игрока
                Input.GetMove(out x, out y, CurrentMove, _players, _desk);

                // обновление доски после хода текущего игрока
                _desk.Update(CurrentMove, x, y);

                // проверям победителя
                if (Check.CheckWinner(CurrentMove, x, y, _desk))
                {
                    // если есть победитель
                    Output.ShowDesk(_desk);
                    Output.ShowWinner(CurrentMove, _players);

                    // обновляем LeaderBord
                    var winnerName = _players[CurrentMove];
                    var looserName = CurrentMove == 1 ? _players[2] : _players[1];

                    // обновляем LeaderBoard
                    _dao.UpdateLeaderBord(winnerName, looserName, true);

                    // спрашиваем у пользователя хочет ли он посмотреть LeaderBoard
                    int answer;
                    Input.ShowBord(out answer);
                    if (answer == 1)
                    {
                        // нужно вывести LeaderBord
                        Output.ShowLeaderBord(_dao);
                    }

                    break;
                }

                // если мы не вышли из цикла - значит текущий игрок не победил
                // значит нужно проверить - а не ничья ли у нас
                if (Check.CheckDraw(_desk))
                {
                    // если ничья
                    Output.ShowDesk(_desk);
                    Output.ShowDraw();

                    // обновляем LeaderBord
                    var winnerName = _players[1];
                    var looserName = _players[2];

                    // обновляем LeaderBoard
                    _dao.UpdateLeaderBord(winnerName, looserName, false);

                    // спрашиваем у пользователя хочет ли он посмотреть LeaderBoard
                    int answer;
                    Input.ShowBord(out answer);
                    if (answer == 1)
                    {
                        // нужно вывести LeaderBord
                        Output.ShowLeaderBord(_dao);
                    }

                    break;
                }


                // если ничьи нет, то продолжаем игру, и значит мы должны изменить текущий ход на другого игрока
                Utilities.UpdateCurrentMove(ref CurrentMove);

                // пытаемся сохранить игру
                _dao.SaveGame(_players, CurrentMove, _desk);
            }
        }
    }
}