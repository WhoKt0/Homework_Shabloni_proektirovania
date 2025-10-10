using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppProduct.Module_5.Prak5.ReportBuilder
{
    public class Report
    {
        public string Header { get; private set; } = "";
        public string Content { get; private set; } = "";
        public string Footer { get; private set; } = "";
        public List<(string Name, string Body)> Sections { get; } = new List<(string, string)>();
        public string MimeType { get; private set; } = "text/plain";
        public string Raw { get; private set; } = "";

        internal void Apply(string header, string content, string footer, IEnumerable<(string,string)> sections, string mime, string raw)
        {
            Header = header ?? "";
            Content = content ?? "";
            Footer = footer ?? "";
            Sections.Clear();
            Sections.AddRange(sections);
            MimeType = mime;
            Raw = raw ?? "";
        }

        public void Export(string path)
        {
            File.WriteAllText(path, Raw, Encoding.UTF8);
        }
    }
}
