using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropServer
{
    class Program
    {
        static void Main(string[] args)
        {
            CropServer server = new CropServer();
            server.Start();
            while (true)
            {  
                Console.WriteLine("Press q to quit.");
                if (Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    server.Stop();
                    break;
                }
                    
                
            }
            
        }
    }
}
