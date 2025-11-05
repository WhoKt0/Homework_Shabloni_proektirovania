using System;
using System.Collections.Generic;

namespace ReportsDecorator.Infrastructure
{
    public static class FakeDataStore
    {
        public static IEnumerable<(DateTime date, string item, double amount)> Sales() => new[]
        {
            (new DateTime(2025,10,01), "T-Shirt", 19.99),
            (new DateTime(2025,10,15), "Sneakers", 79.50),
            (new DateTime(2025,11,01), "Hat", 12.00),
        };

        public static IEnumerable<(string name, int orders)> Users() => new[]
        {
            ("Alice", 5), ("Bob", 2), ("Charlie", 7)
        };
    }
}
