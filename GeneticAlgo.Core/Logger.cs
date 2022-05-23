using Serilog;

namespace GeneticAlgo.Core;

internal class Logger
{
    public static void Init()
    {
        File.WriteAllText("gen-algo.data_log", string.Empty);
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("gen-algo.data_log", rollingInterval: RollingInterval.Minute)
            .CreateLogger();
    }
}