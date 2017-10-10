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
            try
            {
                start();
            }
            catch(Exception ex)
            {
                bool failedToStopToo = false;

                if (stopOnFailedStart)
                {
                    try
                    {
                        stop();
                    }
                    catch
                    {
                        failedToStopToo = true;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{name} has failed to start");

                if (failedToStopToo)
                {
                    Console.Write($" and to stop after that");
                }

                Console.WriteLine($". Message: {ex.Message}.");
                Console.ForegroundColor = ConsoleColor.Gray;

                return;
            }

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

            try
            {
                stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{name} has failed to stop. Message: {ex.Message}.");
            }

            Console.WriteLine("--");
            Console.WriteLine($"{name} is no more.");
        }
    }
}
