using System;

namespace RenjuCheckers
{
    public class ExceptionWithMove : Exception
    {
        // данное исключение создано для того, чтобы пробрасывать его, когда мы хотим вывести
        // сообщение, что на данной ячейке уже стоит фишка
    }
}