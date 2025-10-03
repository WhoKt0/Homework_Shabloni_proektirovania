using System;
using System.Collections.Generic;
using System.IO;

namespace AppProduct.Module_2.Dz2.cs
{
    enum LogLevel { Error, Warning, Info }

    class AppConfig
    {
        public string ConnectionString { get; }
        public AppConfig(string connectionString) => ConnectionString = connectionString;
    }

    class Logger
    {
        private readonly object _sync = new();
        public void Log(LogLevel level, string message)
        {
            var text = $"{DateTime.UtcNow:O} [{level}] {message}";
            Write(text);
        }

        private void Write(string text)
        {
            lock (_sync) Console.WriteLine(text);
        }
    }

    class DatabaseService
    {
        private readonly AppConfig _config;
        public DatabaseService(AppConfig config) => _config = config;
        public bool Connect()
        {
            Console.WriteLine($"Connecting to DB: {_config.ConnectionString}");
            return true;
        }
    }

    class LoggingService
    {
        private readonly AppConfig _config;
        private readonly Logger _logger;
        public LoggingService(AppConfig config, Logger logger) { _config = config; _logger = logger; }
        public void LogToDatabase(string message)
        {
            _logger.Log(LogLevel.Info, $"Persisting log to DB ({_config.ConnectionString}): {message}");
        }
    }

    static class NumberProcessor
    {
        public static void ProcessNumbers(int[] numbers)
        {
            if (numbers == null) return;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0) Console.WriteLine(numbers[i]);
            }
        }

        public static void PrintPositiveNumbers(int[] numbers)
        {
            if (numbers == null) return;
            for (int i = 0; i < numbers.Length; i++)
                if (numbers[i] > 0) Console.WriteLine(numbers[i]);
        }

        public static int SafeDivide(int a, int b)
        {
            if (b == 0) return 0;
            return a / b;
        }
    }

    class User
    {
        public string Name { get; set; }
        public string Email { get; }
        public string Role { get; set; }

        public User(string name, string email, string role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public override string ToString() => $"{Name} <{Email}> ({Role})";
    }

    class FileReader
    {
        public string ReadFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath)) return string.Empty;
            if (!File.Exists(filePath)) return string.Empty;
            return File.ReadAllText(filePath);
        }
    }

    class ReportGenerator
    {
        public void GeneratePdfReport(string title, IEnumerable<string> lines)
        {
            Console.WriteLine($"PDF Report: {title}");
            foreach (var l in lines) Console.WriteLine("  " + l);
        }
    }

    class Program
    {
        static void Main()
        {
            var config = new AppConfig("Server=myServer;Database=myDb;User Id=myUser;Password=myPass;");
            var logger = new Logger();
            var db = new DatabaseService(config);
            var logService = new LoggingService(config, logger);

            db.Connect();
            logger.Log(LogLevel.Info, "Application started");
            logService.LogToDatabase("Startup event recorded");

            int[] nums = { 3, -1, 0, 7 };
            NumberProcessor.ProcessNumbers(nums);
            NumberProcessor.PrintPositiveNumbers(nums);
            Console.WriteLine("Divide 10/2 = " + NumberProcessor.SafeDivide(10, 2));
            Console.WriteLine("Divide 10/0 = " + NumberProcessor.SafeDivide(10, 0));

            var user = new User("Alice", "alice@example.com", "Admin");
            Console.WriteLine(user);

            var reader = new FileReader();
            var content = reader.ReadFile("nonexistent.txt");
            Console.WriteLine("File content length: " + (content?.Length ?? 0));

            var report = new ReportGenerator();
            report.GeneratePdfReport("Users", new[] { user.ToString() });

            logger.Log(LogLevel.Info, "Application finished");
        }
    }
}
