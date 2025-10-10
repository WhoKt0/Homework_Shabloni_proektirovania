using System.Text.Json;
using System.IO;

namespace AppProduct.Module_5.Prak5.SingletonLogger
{
    public class LoggerConfig
    {
        public string FilePath { get; set; } = "";
        public LogLevel Level { get; set; } = LogLevel.Info;

        public static LoggerConfig Load(string path)
        {
            if (!File.Exists(path)) return new LoggerConfig();
            var json = File.ReadAllText(path);
            var cfg = JsonSerializer.Deserialize<LoggerConfig>(json);
            return cfg ?? new LoggerConfig();
        }
    }
}
