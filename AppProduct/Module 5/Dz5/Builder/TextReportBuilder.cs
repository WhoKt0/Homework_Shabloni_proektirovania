namespace AppProduct.Module_5.Dz5.Builder
{
    public class TextReportBuilder : IReportBuilder
    {
        private string _h = "", _c = "", _f = "";
        public void SetHeader(string header) { _h = header; }
        public void SetContent(string content) { _c = content; }
        public void SetFooter(string footer) { _f = footer; }
        public Report GetReport()
        {
            var r = new Report();
            r.Apply(_h, _c, _f);
            return r;
        }
    }
}
