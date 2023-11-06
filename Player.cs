using System;

namespace RenjuCheckers
{
    // Нужен для лидерборда
    public class Player : IComparable
    {
        private string _name;
        private int _victories;

        private int _countOfGame;

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

        // метод для тестирования
        public override string ToString()
        {
            return _name + " " + _victories + " " + _countOfGame;
        }


        // метод для сравнения по убыванию побед
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