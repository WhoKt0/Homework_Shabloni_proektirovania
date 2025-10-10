namespace AppProduct.Module_5.Prak5.ReportBuilder
{
    public interface IReportBuilder
    {
        void SetHeader(string header);
        void SetContent(string content);
        void SetFooter(string footer);
        void AddSection(string sectionName, string sectionContent);
        void SetStyle(ReportStyle style);
        Report GetReport();
    }
}
