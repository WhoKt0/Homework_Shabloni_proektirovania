using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AppProduct.Module_5.Prak5.SingletonLogger
{
    public class LogReader
    {
        readonly string _path;
        public LogReader(string path) { _path = path; }

        public IEnumerable<string> Read(LogLevel? minLevel = null, DateTime? from = null, DateTime? to = null)
        {
            if (!File.Exists(_path)) yield break;
            foreach (var line in File.ReadLines(_path, Encoding.UTF8))
            {
                var lvl = ParseLevel(line);
                var ts = ParseTime(line);
                if (minLevel.HasValue && lvl < minLevel.Value) continue;
                if (from.HasValue && ts < from.Value) continue;
                if (to.HasValue && ts > to.Value) continue;
                yield return line;
            }
        }

        static LogLevel ParseLevel(string line)
        {
            if (line.Contains("[Error]") || line.Contains("[ERROR]")) return LogLevel.Error;
            if (line.Contains("[Warning]") || line.Contains("[WARNING]")) return LogLevel.Warning;
            return LogLevel.Info;
        }

        static DateTime ParseTime(string line)
        {
            var idx = line.IndexOf(' ');
            if (idx > 0 && DateTime.TryParse(line.Substring(0, idx), out var dt)) return dt;
            var upToZ = line.IndexOf('Z');
            if (upToZ > 0 && DateTime.TryParse(line.Substring(0, upToZ+1), out var dt2)) return dt2;
            return DateTime.MinValue;
        }
    }
}
