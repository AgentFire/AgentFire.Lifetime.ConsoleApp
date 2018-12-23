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
        async static Task Main(string[] args)
        {
            //CApp.Lifetime("My app 1", A1, Z1);

            await CApp.LifetimeAsync("My app 2", A2, Z2);
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

        private static async Task A2()
        {
            Console.WriteLine("Starting...");
            await Task.Delay(1000);
            Console.WriteLine("Done.");
        }
        private static async Task Z2()
        {
            Console.WriteLine("Stopping...");
            await Task.Delay(1500);
            throw new Exception("This is expected, isn't it.");
        }
    }
}
