using System;

namespace RenjuCheckers
{
    // Нужен для лидерборда
    public class Player : IComparable
    {
        private string _name;
        private int _victorice;
        private int _countOfGame;

        
        // get для поля victorice
        public int GetVictorice()
        {
            return _victorice;
        }
        
        // констурктор
        public Player(string name, int victorice, int countOfGame)
        {
            _name = name;
            _victorice = victorice;
            _countOfGame = countOfGame;
        }
        
        // метод для тестирования
        public override string ToString()
        {
            return _name + " " + _victorice + " " + _countOfGame;
        }

        // метод для сравнения по убыванию побед
        public int CompareTo(object o)
        {
            var other = (Player) o;
            if (_victorice > other.GetVictorice())
            {
                return -1;
            }

            return 1;
        }
    }
}