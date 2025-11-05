using ReportsDecorator.Abstractions;

namespace ReportsDecorator.Decorators
{
    public class PdfExportDecorator : ReportDecorator
    {
        public PdfExportDecorator(IReport report) : base(report) {}

        public override string Generate()
        {
            // Simulate a PDF export by wrapping the string (no external deps).
            var body = base.Generate();
            return $"<PDF>\n{body}\n</PDF>";
        }
    }
}
