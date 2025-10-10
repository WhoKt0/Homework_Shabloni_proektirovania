using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;

namespace AppProduct.Module_5.Lab5.SingletonLogger
{
    public sealed class Logger
    {
        static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger(), LazyThreadSafetyMode.ExecutionAndPublication);
        public static Logger Instance => _instance.Value;

        readonly object _fileLock = new object();
        readonly ConcurrentQueue<string> _queue = new ConcurrentQueue<string>();
        volatile LogLevel _level = LogLevel.Info;
        string _path = Path.Combine(Path.GetTempPath(), "lab5_logs.txt");

        Logger() { }

        public void SetLogLevel(LogLevel level) => _level = level;
        public void SetLogFilePath(string path) { if (!string.IsNullOrWhiteSpace(path)) _path = path; }

        public void Log(string message, LogLevel level = LogLevel.Info)
        {
            if (level < _level) return;
            var line = $"{DateTime.UtcNow:O} [{level}] {message}";
            _queue.Enqueue(line);
            Flush();
        }

        void Flush()
        {
            if (_queue.IsEmpty) return;
            lock (_fileLock)
            {
                var sb = new StringBuilder();
                while (_queue.TryDequeue(out var line)) sb.AppendLine(line);
                File.AppendAllText(_path, sb.ToString(), Encoding.UTF8);
            }
        }

        public string ReadAll()
        {
            if (!File.Exists(_path)) return "";
            lock (_fileLock) return File.ReadAllText(_path, Encoding.UTF8);
        }
    }
}
