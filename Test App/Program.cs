using AgentFire.Lifetime.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test_App
{
    internal class Program
    {
        private static async Task Main()
        {
            await CApp.LifetimeAsync("My app", MyAsyncStartMethod, MyAsyncStopMethod);
        }
        private static async Task MyAsyncStartMethod()
        {
            Console.WriteLine("Starting...");
            await Task.Delay(1000);
            Console.WriteLine("Done.");
        }
        private static async Task MyAsyncStopMethod()
        {
            Console.WriteLine("Stopping...");
            await Task.Delay(1500);
            throw new Exception("This is expected, isn't it.");
        }
    }
}
