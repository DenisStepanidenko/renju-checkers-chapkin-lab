using System.Collections.Generic;

namespace RenjuCheckers
{
    public class Utilities
    {
        // метод, который после текущего хода игрока - меняет переменную currentMove
        // напоминание: 1 - ходит игрок чёрным ( X )
        // 2 - ходит игрок белыми ( Y )
        public static void UpdateCurrentMove(ref int currentMove)
        {
            currentMove++;
            if (currentMove == 3)
            {
                currentMove = 1;
            }
        }

        public static List<string> GetDeskRows(string[,] matrix)
        {
            var rows = new List<string>();
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                var row = "";

                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    row += matrix[i, j];
                }

                rows.Add(row);
            }

            return rows;
        }

        public static void InitalGame(Dictionary<int, string> players)
        {
            string name1, name2;
            Input.GetName(out name1, out name2);
            Input.GetColor(players, name1, name2);
            Output.ShowRole(players);
        }
    }
}