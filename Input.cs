using System;
using System.Collections.Generic;
using System.Threading;

namespace RenjuCheckers
{
    public class Input
    {
        public static void GetName(out string name1, out string name2)
        {
            Console.WriteLine("Для начала игры введите свои никнеймы");
            Console.WriteLine("--------------------------------------");
            // пытаемся получить имя для первого игрока
            while (true)
            {
                try
                {
                    Console.Write("Игрок 1: ");
                    string name = Console.ReadLine();
                    // теперь нам нужно проверить это имя на корректность
                    // неккоректное имя - пустое имя
                    Check.CheckName(name);
                    name1 = name;
                    break;
                }
                catch
                {
                    Console.WriteLine("Введённое имя неккоректно, имя не может быть пустым");
                }
            }

            // пытаемся получить имя для второго игрока
            while (true)
            {
                try
                {
                    Console.Write("Игрок 2: ");
                    string name = Console.ReadLine();
                    // теперь нам нужно проверить это имя на корректность
                    // неккоректное имя - пустое имя
                    Check.CheckName(name);
                    name2 = name;
                    break;
                }
                catch
                {
                    Console.WriteLine("Введённое имя неккоректно, имя не может быть пустым");
                }
            }
        }

        public static void GetColor(Dictionary<int, string> players, string name1, string name2)
        {
            Console.WriteLine("\nРаспределяем цвета шашек...");
            Thread.Sleep(2500);
            RoleRandomizer.GetRole(players, name1, name2);
            Console.WriteLine("Готово!");
        }

        public static void GetMove(out int x , out int y, ref int currentMove, Dictionary<int, string> players, Desk desk)
        {
            // здесь игроки делают ход
            Console.WriteLine(players[currentMove] + " ваш ход!");
            Console.WriteLine("Напишите его в виде пары чисел (x,y)");
            while (true)
            {
                try
                {
                    Console.Write("X: ");
                    var answerX = Console.ReadLine();
                    Console.Write("Y: ");
                    var answerY = Console.ReadLine();
                    Check.CheckMove(desk, answerX, answerY);
                    x = Convert.ToInt16(answerX);
                    y = Convert.ToInt16(answerY);
                    currentMove++;
                    if (currentMove == 3)
                    {
                        currentMove = 1;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Неккоректно введены данные, повторите попытку");
                }
            }
        }
    }
}