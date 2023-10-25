using System;
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
        
        
        // конструктор
        public CheckersRenju()
        {
            
        }

        // основной класс, где будет происходть действия в игре
        public override void Start()
        {
            Console.WindowWidth = 100; // для того, чтобы красиво влезло сообщение
            // начинаем игру с метода, который предлагает игрокам либо загрузить сохранение, либо начать новую
            int choice;
            while (true)
            {
                try
                {
                    Input.GetNewOrLoad(out choice);
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                        {
                            // здесь инициализируется новая игра
                            string name1, name2;
                            Input.GetName(out name1, out name2);
                            Input.GetColor(_players, name1, name2);
                            Output.ShowRole(_players);
                            break;
                        }
                        case 2:
                        {
                            DAO.LoadGame(_players, ref CurrentMove, _desk);
                            break;
                        }
                    }
                    
                }
                catch (ExceptionWithSaveGame)
                {
                    Console.WriteLine("Упс, кажется вы ещё не сохраняли игру, поэтому сохранение не удалось загрузить!");
                    Console.WriteLine("------------------------------------------------------------------");
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("Произошла непридведенная ошибка при работе с загрузкой сохранения");
                    Console.WriteLine("------------------------------------------------------------------");
                    continue;
                }
                break;
            }
            
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
                    break;
                }
                
                // если мы не вышли из цикла - значит текущий игрок не победил
                // значит нужно проверить - а не ничья ли у нас
                if (Check.CheckDraw(_desk))
                {
                    Output.ShowDesk(_desk);
                    Output.ShowDraw();
                    break;
                }
                
                
                // если ничьи нет, то продолжаем игру, и значит мы должны изменить текущий ход на другого игрока
                Utilities.UpdateCurrentMove(ref CurrentMove);
                
                // пытаемся сохранить игру
                try
                {
                    DAO.SaveGame(_players, CurrentMove, _desk);
                }
                catch
                {
                    
                }
            }
        }
    }
}