using System;
using System.Collections.Generic;
using System.Threading;

namespace RenjuCheckers
{
    public class Input
    {
        // метод, который запрашивает у игроков их никнеймы
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
        
        // метод, который выводит сообщение о том, что началось распределение цветов
        public static void GetColor(Dictionary<int, string> players, string name1, string name2)
        {
            Console.WriteLine("\nРаспределяем цвета шашек...");
            Thread.Sleep(2500);
            RoleRandomizer.GetRole(players, name1, name2);
            Console.WriteLine("Готово!");
        }

        // метод, который запрашивает у игрока его текущий ход
        public static void GetMove(out int x, out int y, int currentMove, Dictionary<int, string> players, Desk desk)
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
                    break;
                }
                catch (ExceptionWithMove e)
                {
                    Console.WriteLine("Данная ячейка уже занята");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Введённые данные неккоректны");
                }
            }
        }
    }
}