﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCounterUse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var counter = new SquareCounter.SquareCounter();
            Console.WriteLine(counter.TriangleSquareCount(4, 5, 2));
            Console.ReadKey();
        }
    }
}
