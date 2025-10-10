using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace AppProduct.Module_5.Dz5.Singleton
{
    public sealed class ConfigurationManager
    {
        private static readonly Lazy<ConfigurationManager> _instance = new Lazy<ConfigurationManager>(() => new ConfigurationManager(), LazyThreadSafetyMode.ExecutionAndPublication);
        public static ConfigurationManager Instance => _instance.Value;

        private readonly ConcurrentDictionary<string, string> _data = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        private ConfigurationManager() { }

        public void Set(string key, string value) => _data[key] = value;

        public string Get(string key, string defaultValue = "") => _data.TryGetValue(key, out var v) ? v : defaultValue;

        public IReadOnlyDictionary<string, string> Snapshot() => new Dictionary<string, string>(_data);

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path)) return;
            foreach (var line in File.ReadAllLines(path, Encoding.UTF8))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                var idx = line.IndexOf('=');
                if (idx <= 0) continue;
                var k = line.Substring(0, idx).Trim();
                var v = line.Substring(idx + 1).Trim();
                _data[k] = v;
            }
        }

        public void SaveToFile(string path)
        {
            var sb = new StringBuilder();
            foreach (var kv in _data)
                sb.AppendLine($"{kv.Key}={kv.Value}");
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }
    }
}
