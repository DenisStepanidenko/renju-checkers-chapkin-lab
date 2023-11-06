
using System.Collections.Generic;
using System.Text;

namespace RenjuCheckers
{
    public class Desk
    {
        private int _filledCount; // показатель того, сколько заполненных ячеек в таблице ( нужно чтобы понять когда ничья)

        private string[,] _matrix; // сама доска, из char (X или Y)

        // конструктор
        public Desk(int size)
        {
            _matrix = new string[size, size]; // инициализация доски
            for (var i = 0; i < _matrix.GetLength(0); i++)
            {
                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    _matrix[i, j] = " ";
                }
            }
        }

        // set для _matrix
        public void SetMatrix(string[,] matrix)
        {
            _matrix = matrix;
        }

        public void SetFilledCount(int filledCount)
        {
            _filledCount = filledCount;
        }

        // get для поля _filledCount
        public int GetFilledCount()
        {
            return _filledCount;
        }

        // get для поля matrix
        public string[,] GetMatrix()
        {
            return _matrix;
        }

       

        //  В данном методе мы будем отображать игровое поле ( матрицу )
        public string Show()
        {
            var stringOfMatrix = new StringBuilder();
            // заполним верхнюю строчку
            stringOfMatrix.Append(
                    "  ___1_____2_____3_____4_____5_____6_____7_____8_____9____1 0___1 1___1 2___1 3___1 4___1 5__")
                .Append('\n');

            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                // нужно так как начиная с 10 меняются логика одного пробела, чтобы ничего не съехало
                if (i >= 9)
                {
                    stringOfMatrix.Append(i + 1 + "|");
                }
                else
                {
                    stringOfMatrix.Append(i + 1 + " |");
                }

                for (var j = 0; j < _matrix.GetLength(1); j++)
                {
                    stringOfMatrix.Append("__" + _matrix[i, j] + "__|");
                }

                stringOfMatrix.Append('\n');
            }

            return stringOfMatrix.ToString();
        }


        // метод, который обновляет матрицу по заданым координатам
        public void Update(int currentMove, int x, int y)
        {
            _filledCount++; // увеличиваем количество заполненных ячеек на единичку
            _matrix[x - 1, y - 1] = ((CharactericticsOfTheGame) currentMove).ToString();
        }

        // получаем диагональ, когда стоим в точке (x;y)
        public List<string> GetDiagonal(int xNew, int yNew, int xModifyer, int yModifyer)
        {
            var x = xNew;
            var y = yNew;
            List<string> diagonal = new();
            int a = x, b = y;
            while ((x >= 0) && (y >= 0) && (x < 15) && (y < 15))
            {
                diagonal.Add(_matrix[x, y]);
                x += xModifyer;
                y += yModifyer;
            }

            diagonal.Reverse();
            x = a + (-xModifyer);
            y = b + (-yModifyer);

            while ((x >= 0) && (y >= 0) && (x < _matrix.GetLength(0)) && (y < _matrix.GetLength(1)))
            {
                diagonal.Add(_matrix[x, y]);
                x += (-xModifyer);
                y += (-yModifyer);
            }

            return diagonal;
        }
    }
}