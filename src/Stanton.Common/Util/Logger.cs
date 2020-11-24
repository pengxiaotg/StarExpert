using System.IO;
using Serilog;
using Serilog.Formatting.Json;

namespace Stanton.Common.Util
{
    public static class Logger
    {
        public static void ConfigureLogger(string applicationPath)
        {
            if (Log.Logger != null)
            {
                return;
            }
            string logFilePath = Path.Combine(Path.Combine(applicationPath, "logs/log.txt"));
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(new JsonFormatter(renderMessage: true), logFilePath)
                .CreateLogger();
            Log.Information("Serilog config completed!");
        }
    }
}
