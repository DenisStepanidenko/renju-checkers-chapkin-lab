using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text;

namespace RenjuCheckers
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //var test = new CheckersRenju();
            //test.Start();

            List<Player> test = new List<Player>();
            test.Add(new Player("denis" , 20 , 1));
            test.Add(new Player("denis" , 205 , 1));
            test.Add(new Player("denis" , 20005 , 1));
            test.Add(new Player("denis" , 1, 1));
            test.Sort();
            foreach (var VARIABLE in test)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}