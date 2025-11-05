using ReportsDecorator.Abstractions;
using System;
using System.Linq;

namespace ReportsDecorator.Decorators
{
    public class DateFilterDecorator : ReportDecorator
    {
        private readonly DateTime _from;
        private readonly DateTime _to;

        public DateFilterDecorator(IReport report, DateTime from, DateTime to) : base(report)
        {
            _from = from;
            _to = to;
        }

        public override string Generate()
        {
            var lines = base.Generate().Split('\n').Where(l =>
            {
                var parts = l.Split('|');
                if (DateTime.TryParse(parts[0].Trim(), out var date))
                {
                    return date >= _from && date <= _to;
                }
                return true; // leave unchanged if parse fails
            });
            return string.Join("\n", lines);
        }
    }
}
