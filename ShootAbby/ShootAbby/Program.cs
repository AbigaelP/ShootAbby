﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootAbby
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Witch player = new Witch();

            Console.Write(player.design);

            Console.ReadLine();
        }
    }
}
