using ReportsDecorator.Abstractions;
using System.Linq;
using System;

namespace ReportsDecorator.Decorators
{
    public class SortingDecorator : ReportDecorator
    {
        private readonly int _columnIndex;
        private readonly bool _descending;

        public SortingDecorator(IReport report, int columnIndex, bool descending = false) : base(report)
        {
            _columnIndex = columnIndex;
            _descending = descending;
        }

        public override string Generate()
        {
            var lines = base.Generate().Split('\n');
            var ordered = lines
                .Select(l => (line: l, key: l.Split('|').ElementAtOrDefault(_columnIndex)?.Trim() ?? string.Empty))
                .OrderBy(t => t.key, StringComparer.Ordinal);
            if (_descending) ordered = ordered.Reverse();
            return string.Join("\n", ordered.Select(t => t.line));
        }
    }
}
