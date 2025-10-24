using System;
using System.IO;

namespace AppProduct.Module_7.Prak7.Reports.Template
{
    public abstract class ReportGenerator
    {
        public void Generate(string title, string data, string outputPath)
        {
            Log("Start");
            var prepared = PrepareData(data);
            var formatted = Format(prepared);
            var content = Render(title, formatted);
            if (CustomerWantsSave())
            {
                Save(outputPath, content);
                Log($"Saved to {outputPath}");
            }
            else
            {
                SendByEmail(content);
                Log("Sent by email (demo)");
            }
            Log("Done");
        }

        protected virtual string PrepareData(string data) => data?.Trim() ?? string.Empty;
        protected abstract string Format(string prepared);
        protected abstract string Render(string title, string body);
        protected virtual bool CustomerWantsSave() => true;
        protected virtual void Save(string path, string content) => File.WriteAllText(path, content);
        protected virtual void SendByEmail(string content) => Console.WriteLine("[EMAIL]\n" + content);
        protected virtual void Log(string msg) => Console.WriteLine("[REPORT] " + msg);
    }
}
