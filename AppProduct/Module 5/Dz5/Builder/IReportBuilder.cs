namespace AppProduct.Module_5.Dz5.Builder
{
    public interface IReportBuilder
    {
        void SetHeader(string header);
        void SetContent(string content);
        void SetFooter(string footer);
        Report GetReport();
    }
}
