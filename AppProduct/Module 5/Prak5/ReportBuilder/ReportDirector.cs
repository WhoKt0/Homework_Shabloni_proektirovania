namespace AppProduct.Module_5.Prak5.ReportBuilder
{
    public class ReportDirector
    {
        public Report ConstructReport(IReportBuilder builder, ReportStyle style, (string h,string c,string f) content, params (string name,string body)[] sections)
        {
            builder.SetStyle(style);
            builder.SetHeader(content.h);
            builder.SetContent(content.c);
            builder.SetFooter(content.f);
            foreach (var s in sections) builder.AddSection(s.name, s.body);
            return builder.GetReport();
        }
    }
}
