﻿using System;
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
            var test = new CheckersRenju();
            test.Start();
        }
    }
}