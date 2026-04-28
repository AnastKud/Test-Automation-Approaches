using Serilog;
using System.IO;

namespace EhuTestsFinal.Utils
{
    public static class Logger
    {
        static Logger()
        {
            Directory.CreateDirectory("logs");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void Debug(string msg) => Log.Debug(msg);
        public static void Info(string msg) => Log.Information(msg);
        public static void Warning(string msg) => Log.Warning(msg);
        public static void Error(string msg) => Log.Error(msg);
        public static void Fatal(string msg) => Log.Fatal(msg);
    }
}