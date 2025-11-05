using ReportsDecorator.Abstractions;

namespace ReportsDecorator.Decorators
{
    public abstract class ReportDecorator : IReport
    {
        protected readonly IReport _report;
        protected ReportDecorator(IReport report) => _report = report;
        public virtual string Generate() => _report.Generate();
    }
}
