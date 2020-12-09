using Serilog;
using System;
using System.IO;
using Windows.Storage;

namespace Stanton.App.Services
{
    public static class LogService
    {
        public static void ConfigLogger()
        {
            string fileName = DateTime.Today.Date.ToString("yyyy_MM_dd") + ".log";
            string filePath = Path.Combine(ApplicationData.Current.LocalCacheFolder.Path, "logs");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(Path.Combine(filePath, fileName))
                .CreateLogger();
            Log.Information("Serilog config completed!");
        }
    }
}
