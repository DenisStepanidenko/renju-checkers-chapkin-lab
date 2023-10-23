namespace RenjuCheckers
{
    public class UtilitiesMove
    {
        // метод, что 
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