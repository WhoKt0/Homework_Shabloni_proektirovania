using System;
using System.IO;
using AppProduct.Module_7.Prak7.Reports.Concrete;

namespace AppProduct.Module_7.Prak7.Reports
{
    class Program
    {
        static void Main()
        {
            var data = "id;name\n1;Alice\n2;Bob";
            Directory.CreateDirectory("out");

            var pdf = new PdfReport();
            pdf.Generate("Отчёт PDF", data, Path.Combine("out", "report.pdf.txt"));

            var excel = new ExcelReport();
            excel.Generate("Отчёт Excel", data, Path.Combine("out", "report.csv"));

            var html = new HtmlReport();
            html.Generate("Отчёт HTML", data, Path.Combine("out", "report.html"));

            var csv = new CsvReport();
            csv.Generate("Отчёт CSV", data, Path.Combine("out", "report2.csv"));

            Console.WriteLine("Готово.");
        }
    }
}
