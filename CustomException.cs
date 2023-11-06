using System;

namespace RenjuCheckers
{
    public class ExceptionWithMove : Exception
    {
        public override string ToString()
        {
            return "Данная ячейка уже занята";
        }
        // данное исключение создано для того, чтобы пробрасывать его, когда мы хотим вывести
        // сообщение, что на данной ячейке уже стоит фишка
    }

    public class ExceptionWithChoiceGetOrLoad : Exception
    {
        public override string ToString()
        {
            return "Введёная цифра должно быть либо 1, либо 2. Повторите ввод данных, пожалуйста.";
        }
        // данное исключение говорит о том, что пользователь ввёл не ту цифру, при выборе
        // загрузить игру или же начать новую
    }

    public class ExceptionWithSaveGame : Exception
    {
        public override string ToString()
        {
            return "Пока что нет сохранённых игр";
        }
        // данное исключение говорит о том, что файл с сохранением открылся, но данных там нет
        // то есть нет сохранённой игры на текущий момент
    }

    public class ExceptionWithLeaderBord : Exception
    {
        public override string ToString()
        {
            return "В файле с LeaderBoard'ом нет данных";
        }
        // данное исключение говорит о том, что файл с leaderbord открылся, но данных там нет
    }

    public class ExceptionWithAnswerFromLeaderBord : Exception
    {
        public override string ToString()
        {
            return "Введёная цифра должно быть либо 1, либо 2. Повторите ввод данных, пожалуйста.";
        }
        // данное исключение говорит о том, что пользователь ввёл не ту цифру, при выборе
        // показать leaderBord или же нет
    }
}