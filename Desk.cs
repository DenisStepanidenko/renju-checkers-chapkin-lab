using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace RenjuCheckers
{
    public class Desk
    {
        private int _filledCount = 0; // показатель того, сколько заполненных ячеек в таблице ( нужно чтобы понять когда ничья)

        private string[,] matrix; // сама доска, из char (X или Y)

        public Desk(int size)
        {
            matrix = new string[size, size]; // инициализация доски
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = " ";
                }
            }
        }
        public int GetFilledCount()
        {
            return _filledCount;
        }

        public string[,] GetMatrix()
        {
            return matrix;
        }

        public string Show()
        {
            //  данном методе мы будем отображать доску
            StringBuilder stringOfMatrix = new StringBuilder();
            // заполним верхнюю строчку
            stringOfMatrix.Append(
                    "  ___1_____2_____3_____4_____5_____6_____7_____8_____9____1 0___1 1___1 2___1 3___1 4___1 5__")
                .Append('\n');

            for (int i = 0; i < matrix.GetLength(0); i++)
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

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    stringOfMatrix.Append("__" + matrix[i, j] + "__|");
                }

                stringOfMatrix.Append('\n');
            }

            return stringOfMatrix.ToString();
        }

        public void Update(int currentMove, int x, int y)
        {
            _filledCount++; // увеличиваем количество заполненных ячеек на единичку
            matrix[x - 1, y - 1] = ((CharactericticsOfTheGame) currentMove).ToString();
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
                diagonal.Add(matrix[x, y]);
                x += xModifyer;
                y += yModifyer;
            }

            diagonal.Reverse();
            x = a + (-xModifyer);
            y = b + (-yModifyer);

            while ((x >= 0) && (y >= 0) && (x < matrix.GetLength(0)) && (y < matrix.GetLength(1)))
            {
                diagonal.Add(matrix[x, y]);
                x += (-xModifyer);
                y += (-yModifyer);
            }

            return diagonal;
        }
    }
}