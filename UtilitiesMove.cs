namespace RenjuCheckers
{
    public class UtilitiesMove
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
    }
}