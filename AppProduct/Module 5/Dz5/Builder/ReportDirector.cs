namespace AppProduct.Module_5.Dz5.Builder
{
    public class ReportDirector
    {
        public Report ConstructReport(IReportBuilder builder, string header, string content, string footer)
        {
            builder.SetHeader(header);
            builder.SetContent(content);
            builder.SetFooter(footer);
            return builder.GetReport();
        }
    }
}
