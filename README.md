# AgentFire.Lifetime.ConsoleApp
Provides a simple way to manage the lifetime of a console application.

    async static Task Main()
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
    
Output:

```console
Launching My app in console mode...
--
Starting...
Done.
--
Startup is successful. Press Ctrl-C to shutdown.
--
--
Stopping My app...
--
Stopping...
Exception on the stop method.

System.Exception: This is expected, isn't it.
   at Test_App.Program.<MyAsyncStopMethod>d__2.MoveNext()
   <...>
   
--
My app is no more.
Press any key to exit.
```
