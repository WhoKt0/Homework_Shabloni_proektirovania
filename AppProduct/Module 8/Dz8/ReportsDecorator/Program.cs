using System;
using ReportsDecorator.Abstractions;
using ReportsDecorator.Reports;
using ReportsDecorator.Decorators;
using ReportsDecorator.Infrastructure;

namespace ReportsDecorator
{
    public static class Program
    {
        public static void Main()
        {
            IReport sales = new SalesReport(FakeDataStore.Sales());
            sales = new DateFilterDecorator(sales, new DateTime(2025,10,1), new DateTime(2025,10,31));
            sales = new SortingDecorator(sales, columnIndex: 2, descending: true); // sort by amount (3rd col)
            var csv = new CsvExportDecorator(sales).Generate();
            Console.WriteLine(csv);

            IReport users = new UserReport(FakeDataStore.Users());
            var pdf = new PdfExportDecorator(users).Generate();
            Console.WriteLine(pdf);
        }
    }
}
