using System;

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
        public static void CheckMove(Desk desk, string answerX , string answerY)
        {
            int xTheory = Convert.ToInt16(answerX);
            int yTheory = Convert.ToInt16(answerY);
            // простая проверка на выходы за границу поля
            if ( (xTheory > CheckersRenju.DeskSize || xTheory < 1) || (yTheory > CheckersRenju.DeskSize || yTheory < 1))
            {
               throw new Exception();
            }
            desk.CheckCoord(xTheory , yTheory);
        }
    }
}