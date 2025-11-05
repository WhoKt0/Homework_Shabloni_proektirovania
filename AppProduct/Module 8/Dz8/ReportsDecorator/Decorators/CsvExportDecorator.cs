using ReportsDecorator.Abstractions;

namespace ReportsDecorator.Decorators
{
    public class CsvExportDecorator : ReportDecorator
    {
        public CsvExportDecorator(IReport report) : base(report) {}

        public override string Generate()
        {
            // Convert " | " to CSV commas for a naive export.
            var body = base.Generate();
            return body.Replace(" | ", ",");
        }
    }
}
