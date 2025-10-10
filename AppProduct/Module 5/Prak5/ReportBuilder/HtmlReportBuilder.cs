using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AppProduct.Module_5.Prak5.ReportBuilder
{
    public class HtmlReportBuilder : IReportBuilder
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
            sb.Append("<!doctype html><html><head><meta charset='utf-8'><title>");
            sb.Append(WebUtility.HtmlEncode(_h));
            sb.Append("</title></head><body style='background:");
            sb.Append(_style.BackgroundColor);
            sb.Append(";color:");
            sb.Append(_style.FontColor);
            sb.Append(";font-size:");
            sb.Append(_style.FontSize);
            sb.Append("px;'>");
            sb.Append("<h1>");
            sb.Append(WebUtility.HtmlEncode(_h));
            sb.Append("</h1><div>");
            sb.Append(WebUtility.HtmlEncode(_c));
            sb.Append("</div>");
            foreach (var s in _sections)
            {
                sb.Append("<h2>");
                sb.Append(WebUtility.HtmlEncode(s.Item1));
                sb.Append("</h2><p>");
                sb.Append(WebUtility.HtmlEncode(s.Item2));
                sb.Append("</p>");
            }
            sb.Append("<footer><small>");
            sb.Append(WebUtility.HtmlEncode(_f));
            sb.Append("</small></footer></body></html>");
            var r = new Report();
            r.Apply(_h, _c, _f, _sections, "text/html", sb.ToString());
            return r;
        }
    }
}
