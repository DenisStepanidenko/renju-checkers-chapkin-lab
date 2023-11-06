using System;

namespace RenjuCheckers
{
    // Нужен для лидерборда, чтобы сортировать по убыванию побед
    public class Player : IComparable
    {
        private string _name; // имя игрока
        private int _victories; // количество побед

        private int _countOfGame; // количество всего игр

        // get для поля victorice
        public int GetVictorice()
        {
            return _victories;
        }

        // констурктор
        public Player(string name, int victories, int countOfGame)
        {
            _name = name;
            _victories = victories;
            _countOfGame = countOfGame;
        }

        /// <summary>
        /// Метод, который выводит информацию об игроке
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _name + " " + _victories + " " + _countOfGame;
        }


        /// <summary>
        /// Метод для сравнения игроков между собой по убыванию побед
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public int CompareTo(object o)
        {
            var other = (Player) o;
            if (_victories > other.GetVictorice())
            {
                return -1;
            }

            return 1;
        }
    }
}