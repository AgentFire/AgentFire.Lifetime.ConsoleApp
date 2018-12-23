using System;
using System.Threading.Tasks;

namespace AgentFire.Lifetime.ConsoleApp
{
    public static class CApp
    {
        public static async Task LifetimeAsync(string name, Func<Task> start, Func<Task> stop)
        {
            Console.WriteLine($"Launching {name} in console mode...");
            Console.WriteLine("--");

            Console.TreatControlCAsInput = true;

            await GoInternalAsync(name, start, stop).ConfigureAwait(false);

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey(true);
        }
        private static void WriteException(Exception ex, string methodName)
        {
            ConsoleColor last = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Exception on the {methodName} method.");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(ex.ToString());
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"You should probably log your own business, young man.");

            Console.ForegroundColor = last;

        }
        private static async Task GoInternalAsync(string name, Func<Task> start, Func<Task> stop)
        {
            try
            {
                await Task.Run(start).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                WriteException(ex, nameof(start));
                return;
            }

            Console.WriteLine("--");
            Console.WriteLine("Startup is successful. Press Ctrl-C to shutdown.");
            Console.WriteLine("--");

            await Task.Run(() =>
            {
                ConsoleKeyInfo info;

                do
                {
                    info = Console.ReadKey(true);
                } while (info.Key != ConsoleKey.C || info.Modifiers != ConsoleModifiers.Control);
            });

            Console.WriteLine("--");
            Console.WriteLine($"Stopping {name}...");
            Console.WriteLine("--");

            try
            {
                await Task.Run(stop).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                WriteException(ex, nameof(stop));
            }

            Console.WriteLine("--");
            Console.WriteLine($"{name} is no more.");
        }
    }
}
