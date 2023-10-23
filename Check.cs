using System;
using System.Collections.Generic;

namespace RenjuCheckers
{
    public class Check
    {
        public static void CheckName(string s)
        {
            // нужно проверить, не пустое ли имя
            if (string.IsNullOrEmpty(s))
            {
                throw new Exception();
            }
        }

        public static void CheckMove(Desk desk, string answerX, string answerY)
        {
            int xTheory = Convert.ToInt16(answerX);
            int yTheory = Convert.ToInt16(answerY);
            // простая проверка на выходы за границу поля
            if ((xTheory > CheckersRenju.DeskSize || xTheory < 1) || (yTheory > CheckersRenju.DeskSize || yTheory < 1))
            {
                throw new Exception();
            }

            CheckCoord(xTheory, yTheory, desk);
        }

        public static void CheckCoord(int x, int y, Desk desk)
        {
            var matrix = desk.GetMatrix();
            ;
            if (matrix[x - 1, y - 1] != " ")
            {
                // это означает, что по этим координатам уже стоит чья-то фишка
                throw new ExceptionWithMove();
            }
        }

        // метод, в котором мы проверяем ничью
        // данный метод вызывается, если игрок сделал ход и всё ещё не победил
        public static bool CheckDraw(Desk desk)
        {
            if (desk.GetFilledCount() >= Math.Pow(((int) CharactericticsOfTheGame.DeskSize), 2))
            {
                return true;
            }

            return false;
        }


        public static bool CheckWinner(int currentMove, int xNew, int yNew, Desk desk)
        {
            var x = xNew - 1;
            var y = yNew - 1;
            var matrix = desk.GetMatrix();
            int hrzCount = 0, vertCount = 0, d1Count = 0, d2Count = 0;

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, y] == ((CharactericticsOfTheGame) currentMove).ToString())
                {
                    hrzCount++;
                }
                else
                    hrzCount = 0;

                if (matrix[x, i] == ((CharactericticsOfTheGame) currentMove).ToString())
                {
                    vertCount++;
                }
                else
                    vertCount = 0;

                if (hrzCount >= (CheckersRenju.WinningRowSize) || (vertCount >= CheckersRenju.WinningRowSize))
                {
                    return true;
                }
            }

            var d1 = desk.GetDiagonal(x, y, -1, -1);
            var d2 = desk.GetDiagonal(x, y, 1, -1);

            foreach (var el in d1)
            {
                if (el == ((CharactericticsOfTheGame) currentMove).ToString()) d1Count++;

                else d1Count = 0;

                if (d1Count >= CheckersRenju.WinningRowSize)
                {
                    return true;
                }
            }

            foreach (var el in d2)
            {
                if (el == ((CharactericticsOfTheGame) currentMove).ToString()) d2Count++;

                else d2Count = 0;

                if (d2Count >= CheckersRenju.WinningRowSize)
                {
                    return true;
                }
            }

            return false;
        }
    }
}