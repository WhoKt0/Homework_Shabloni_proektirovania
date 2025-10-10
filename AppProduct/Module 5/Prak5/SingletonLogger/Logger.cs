using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace AppProduct.Module_5.Prak5.SingletonLogger
{
    public sealed class Logger
    {
        static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger(), LazyThreadSafetyMode.ExecutionAndPublication);
        public static Logger Instance => _instance.Value;

        readonly object _fileLock = new object();
        readonly ConcurrentQueue<string> _queue = new ConcurrentQueue<string>();
        volatile LogLevel _level = LogLevel.Info;
        string _path = Path.Combine(Path.GetTempPath(), "prak5_logs.txt");
        long _maxBytes = 1024 * 1024;

        Logger() { }

        public void LoadConfig(string jsonPath)
        {
            var cfg = LoggerConfig.Load(jsonPath);
            if (!string.IsNullOrWhiteSpace(cfg.FilePath)) _path = cfg.FilePath;
            _level = cfg.Level;
        }

        public void SetLogLevel(LogLevel level) => _level = level;
        public void SetLogFilePath(string path) { if (!string.IsNullOrWhiteSpace(path)) _path = path; }
        public void SetMaxSizeBytes(long bytes) { if (bytes > 0) _maxBytes = bytes; }

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
                RotateIfNeeded();
                var sb = new StringBuilder();
                while (_queue.TryDequeue(out var line)) sb.AppendLine(line);
                File.AppendAllText(_path, sb.ToString(), Encoding.UTF8);
            }
        }

        void RotateIfNeeded()
        {
            try
            {
                if (!File.Exists(_path)) return;
                var fi = new FileInfo(_path);
                if (fi.Length < _maxBytes) return;
                var dir = Path.GetDirectoryName(_path) ?? ".";
                var name = Path.GetFileNameWithoutExtension(_path);
                var ext = Path.GetExtension(_path);
                var rotated = Path.Combine(dir, $"{name}_{DateTime.UtcNow:yyyyMMdd_HHmmss}{ext}");
                File.Move(_path, rotated);
            }
            catch { }
        }

        public string ReadAll()
        {
            if (!File.Exists(_path)) return "";
            lock (_fileLock) return File.ReadAllText(_path, Encoding.UTF8);
        }
    }
}
