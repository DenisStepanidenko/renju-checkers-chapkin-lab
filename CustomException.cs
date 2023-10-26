using System;

namespace RenjuCheckers
{
    public class ExceptionWithMove : Exception
    {
        // данное исключение создано для того, чтобы пробрасывать его, когда мы хотим вывести
        // сообщение, что на данной ячейке уже стоит фишка
    }

    public class ExceptionWithChoiceGetOrLoad : Exception
    {
        // данное исключение говорит о том, что пользователь ввёл не ту цифру, при выборе
        // загрузить игру или же начать новую
    }

    public class ExceptionWithSaveGame : Exception
    {
        // данное исключение говорит о том, что файл с сохранением открылся, но данных там нет
        // то есть нет сохранённой игры на текущий момент
    }
    public class ExceptionWithLeaderBord : Exception
    {
        // данное исключение говорит о том, что файл с leaderbord открылся, но данных там нет
    }
    public class ExceptionWithAnswerFromLeaderBord : Exception
    {
        // данное исключение говорит о том, что пользователь ввёл не ту цифру, при выборе
        // показать leaderBord или же нет
    }
}