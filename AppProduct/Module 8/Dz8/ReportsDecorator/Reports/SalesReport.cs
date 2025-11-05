using ReportsDecorator.Abstractions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ReportsDecorator.Reports
{
    public class SalesReport : IReport
    {
        private readonly IEnumerable<(DateTime date, string item, double amount)> _data;
        public SalesReport(IEnumerable<(DateTime date, string item, double amount)> data) => _data = data;

        public string Generate()
        {
            return string.Join("\n", _data.Select(r => $"{r.date:yyyy-MM-dd} | {r.item} | {r.amount:0.00}"));
        }
    }
}
