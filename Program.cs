using System;

namespace RenjuCheckers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var path = Environment.CurrentDirectory; // получаем путь откуда открывают файл, это нужно для создания правильного пути к БД
            var test = new CheckersRenju(path);
            test.Start();
        }
    }
}