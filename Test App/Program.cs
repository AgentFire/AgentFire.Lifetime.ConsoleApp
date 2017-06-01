using AgentFire.Lifetime.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test_App
{
    class Program
    {
        static void Main(string[] args)
        {
            //CApp.Lifetime("My app 1", A1, Z1);
            CApp.Lifetime("My app 2", A2, Z2, false);
        }

        private static void A1()
        {
            Console.WriteLine("Starting...");
            Thread.Sleep(1000);
            Console.WriteLine("Done.");
        }
        private static void Z1()
        {
            Console.WriteLine("Stopping...");
            Thread.Sleep(300);
            Console.WriteLine("Done.");
        }

        private static void A2()
        {
            Console.WriteLine("Starting...");
            Thread.Sleep(1000);
            throw new Exception();
        }
        private static void Z2()
        {
            Console.WriteLine("Stopping...");
            Thread.Sleep(1500);
            throw new Exception();
        }
    }
}
