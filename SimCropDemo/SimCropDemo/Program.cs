﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCropServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server started.");

            while (true)
            {
                Console.WriteLine("Press q to quit.");
                if (Console.ReadKey(true).Key == ConsoleKey.Q)
                    break;
                
            }
            
        }
    }
}
