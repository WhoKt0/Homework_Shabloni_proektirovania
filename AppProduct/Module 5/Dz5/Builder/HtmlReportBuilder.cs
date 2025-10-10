namespace AppProduct.Module_5.Dz5.Builder
{
    public class HtmlReportBuilder : IReportBuilder
    {
        private string _h = "", _c = "", _f = "";
        public void SetHeader(string header) { _h = $"<h1>{System.Net.WebUtility.HtmlEncode(header)}</h1>"; }
        public void SetContent(string content) { _c = $"<div>{System.Net.WebUtility.HtmlEncode(content)}</div>"; }
        public void SetFooter(string footer) { _f = $"<small>{System.Net.WebUtility.HtmlEncode(footer)}</small>"; }
        public Report GetReport()
        {
            var r = new Report();
            r.Apply(_h, _c, _f);
            return r;
        }
    }
}
