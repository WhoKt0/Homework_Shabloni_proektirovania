using System.Collections.Generic;
using System.Text;

namespace AppProduct.Module_5.Prak5.ReportBuilder
{
    public class PdfReportBuilder : IReportBuilder
    {
        string _h = "", _c = "", _f = "";
        readonly List<(string,string)> _sections = new List<(string,string)>();
        ReportStyle _style = new ReportStyle();

        public void SetHeader(string header) { _h = header; }
        public void SetContent(string content) { _c = content; }
        public void SetFooter(string footer) { _f = footer; }
        public void AddSection(string sectionName, string sectionContent) { _sections.Add((sectionName, sectionContent)); }
        public void SetStyle(ReportStyle style) { _style = style ?? new ReportStyle(); }
        public Report GetReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine(_h);
            sb.AppendLine(_c);
            foreach (var s in _sections)
            {
                sb.AppendLine($"[Section] {s.Item1}");
                sb.AppendLine(s.Item2);
            }
            sb.AppendLine(_f);
            var r = new Report();
            r.Apply(_h, _c, _f, _sections, "application/pdf", sb.ToString());
            return r;
        }
    }
}
