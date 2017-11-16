using System;

namespace AgentFire.Lifetime.ConsoleApp
{
    public static class CApp
    {
        public static void Lifetime(string name, Action start, Action stop, bool stopOnFailedStart = true)
        {
            Console.WriteLine($"Launching {name} in console mode...");
            Console.WriteLine("--");

            Console.TreatControlCAsInput = true;

            GoInternal(name, start, stop, stopOnFailedStart);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }

        private static void GoInternal(string name, Action start, Action stop, bool stopOnFailedStart)
        {
            start();

            Console.WriteLine("--");
            Console.WriteLine("Startup is successful. Press Ctrl-C to shutdown.");
            Console.WriteLine("--");

            ConsoleKeyInfo info;
            do
            {
                info = Console.ReadKey(true);
            } while (info.Key != ConsoleKey.C || info.Modifiers != ConsoleModifiers.Control);

            Console.WriteLine("--");
            Console.WriteLine($"Stopping {name}...");
            Console.WriteLine("--");

            stop();

            Console.WriteLine("--");
            Console.WriteLine($"{name} is no more.");
        }
    }
}
