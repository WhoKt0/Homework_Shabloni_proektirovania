using ReportsDecorator.Abstractions;
using System.Linq;
using System.Collections.Generic;

namespace ReportsDecorator.Reports
{
    public class UserReport : IReport
    {
        private readonly IEnumerable<(string name, int orders)> _data;
        public UserReport(IEnumerable<(string name, int orders)> data) => _data = data;

        public string Generate()
        {
            return string.Join("\n", _data.Select(r => $"{r.name} | orders: {r.orders}"));
        }
    }
}
