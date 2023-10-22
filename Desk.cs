using System;
using System.Security.AccessControl;
using System.Text;

namespace RenjuCheckers
{
    public class Desk
    {
        private int
            filledCount; // показатель того, сколько заполненных ячеек в таблице ( нужно чтобы понять когда ничья)

        private string[,] matrix; // сама доска, из char (X или Y)

        public Desk(int size)
        {
            matrix = new string[size, size]; // инициализация доски
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = " ";
                }
            }
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
            matrix[x - 1, y - 1] = ((CharactericticsOfTheGame) currentMove).ToString();
        }

        public void CheckCoord(int x, int y)
        {
            if (matrix[x-1, y-1] != " ")
            {
                // это означает, что по этим координатам уже стоит чья-то фишка
                throw new Exception();
            }
        }
        public void CheckWinner(int currentMove, int x, int y)
        {

            int hrzCount = 0, vertCount = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, y] != " ")
                {
                    hrzCount++;
                }
                else
                    hrzCount = 0;

                if (matrix[x, i] == " ")
                {
                    vertCount++;
                }
                else
                    vertCount = 0;

                if (hrzCount >= (CheckersRenju.DeskSize) || (vertCount >= CheckersRenju.DeskSize))
                {
                    //flag = false;
                    break;
                }
            }
        }
    }
}