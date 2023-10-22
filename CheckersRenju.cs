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

        private Desk _desk = new Desk(DeskSize);
        public int CurrentMove = 1; // текущий ход игрока, если 1 - чёрные, 2 - белые

        public CheckersRenju()
        {
        }


        // основной класс, где будет происходть действия в игре
        public override void Start()
        {
            string name1, name2;
            Input.GetName(out name1, out name2);
            Input.GetColor(_players, name1, name2);
            Output.ShowRole(_players);
            Output.ShowDesk(_desk);
            while (true)
            {
                int x, y;
                Input.GetMove(out x, out y, ref CurrentMove, _players, _desk);
                _desk.Update(CurrentMove, x, y);
                Output.ShowDesk(_desk);
            }
        }
    }
}