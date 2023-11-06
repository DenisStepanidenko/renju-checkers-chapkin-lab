using System;


namespace RenjuCheckers
{
    public class Check
    {
        /// <summary>
        /// Данный метод проверяет на корректность введёное имя пользователем
        /// </summary>
        /// <param name="s">Имя пользователя</param>
        /// <exception cref="Exception">Исключение выбрасываем в метод Input, чтобы пользователь повторил ввод</exception>
        public static void CheckName(string s)
        {
            // нужно проверить, не пустое ли имя
            if (string.IsNullOrEmpty(s))
            {
                throw new Exception();
            }
        }
        
        
        /// <summary>
        /// проверка на корректность хода текущего игрока
        /// </summary>
        /// <param name="desk">Объект класса Desk</param>
        /// <param name="answerX">Ответ игрока по x</param>
        /// <param name="answerY">Ответ игрока по y</param>
        /// <exception cref="Exception">Исключение выбрасываем в метод Input, чтобы пользователь повторил ввод</exception>
        public static void CheckMove(Desk desk, string answerX, string answerY)
        {
            int xTheory = Convert.ToInt16(answerX);
            int yTheory = Convert.ToInt16(answerY);
            // простая проверка на выходы за границу поля
            if ((xTheory > CheckersRenju.DeskSize || xTheory < 1) || (yTheory > CheckersRenju.DeskSize || yTheory < 1))
            {
                throw new Exception();
            }
            
            // метод, который смотрит - не занята ли данная ячейка, если она введена правильно
            CheckCoord(xTheory, yTheory, desk);
        }
        
        /// <summary>
        /// метод для проверки координаты ( что по данным координатам не стоит ни чья фишка )
        /// </summary>
        /// <param name="x">Координата по x</param>
        /// <param name="y">Координата по y</param>
        /// <param name="desk">Объект класса desk</param>
        /// <exception cref="ExceptionWithMove">Исключение выбрасываем в метод Input, чтобы пользователь повторил ввод</exception>
        public static void CheckCoord(int x, int y, Desk desk)
        {
            var matrix = desk.GetMatrix();
            if (matrix[x - 1, y - 1] != " ")
            {
                // это означает, что по этим координатам уже стоит чья-то фишка
                throw new ExceptionWithMove();
            }
        }

        
        /// <summary>
        /// метод, в котором мы проверяем ничью
        /// данный метод вызывается, если игрок сделал ход и всё ещё не победил
        /// </summary>
        /// <param name="desk">Объект класса Desk</param>
        /// <returns></returns>
        public static bool CheckDraw(Desk desk)
        {
            return desk.GetFilledCount() >= Math.Pow(((int) CharactericticsOfTheGame.DeskSize), 2);
        }
        
        
        /// <summary>
        /// проверка на победителя
        /// </summary>
        /// <param name="currentMove">Сохранен текущий ход ( 1 - игрок чёрными шашками, 2 - игрок белыми шашками)</param>
        /// <param name="xNew">Координата вновь поставленной точки по x</param>
        /// <param name="yNew">Координата вновь поставленной точки по y</param>
        /// <param name="desk">Объект класса Desk</param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Метод проверяет ответ от пользователя на вопрос - загрузить или начать новую игру
        /// </summary>
        /// <param name="s"></param>
        /// <exception cref="ExceptionWithChoiceGetOrLoad"></exception>
        public static void CheckChoiceGetOrLoad(string s)
        {
            int choice = Convert.ToInt16(s);
            if (!(choice >= 1 && choice <= 2))
            {
                throw new ExceptionWithChoiceGetOrLoad();
            }
        }
        
        /// <summary>
        /// Метод проверяет ответ от пользователям на вопрос - показать ли лидерборд или нет
        /// </summary>
        /// <param name="answer"></param>
        /// <exception cref="ExceptionWithAnswerFromLeaderBord"></exception>
        public static void CheckLeaderBord(string answer)
        {
            int n = Convert.ToInt16(answer);
            if (!(n >= 1 && n <= 2))
            {
                throw new ExceptionWithAnswerFromLeaderBord();
            }
        }
    }
}