using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using AppProduct.Module_5.Dz5.Singleton;
using AppProduct.Module_5.Dz5.Builder;
using AppProduct.Module_5.Dz5.Prototype;

namespace AppProduct.Module_5.Dz5
{
    public class Program5
    {
        public static void Main()
        {
            var cfg = ConfigurationManager.Instance;
            var path = Path.Combine(Path.GetTempPath(), "app_cfg.txt");
            cfg.Set("env", "dev");
            cfg.Set("version", "1.0");
            cfg.SaveToFile(path);
            var c1 = ConfigurationManager.Instance;
            var c2 = ConfigurationManager.Instance;
            Console.WriteLine(object.ReferenceEquals(c1, c2) ? "Singleton OK" : "Singleton FAIL");

            var tasks = Enumerable.Range(0, 8).Select(i => Task.Run(() =>
            {
                ConfigurationManager.Instance.Set($"k{i}", $"v{i}");
            })).ToArray();
            Task.WaitAll(tasks);
            Console.WriteLine($"Settings count: {cfg.Snapshot().Count}");

            var director = new ReportDirector();
            var textReport = director.ConstructReport(new TextReportBuilder(), "Report A", "Content body", "Footer 2025");
            var htmlReport = director.ConstructReport(new HtmlReportBuilder(), "Sales", "Items sold", "© Company");
            Console.WriteLine("TEXT:");
            Console.WriteLine(textReport.ToString());
            Console.WriteLine("HTML:");
            Console.WriteLine(htmlReport.ToString());

            var baseOrder = new Order("alice@example.com");
            baseOrder.Items.Add(new OrderItem(new Product("TS-01", "T-Shirt", 25m), 2));
            baseOrder.Items.Add(new OrderItem(new Product("MG-01", "Mug", 8.5m), 3));
            baseOrder.Discounts.Add(new Discount("WELCOME5", 5m, false));
            baseOrder.ShippingCost = 7m;
            baseOrder.PaymentMethod = "Card";

            var orderB = baseOrder.Clone();
            orderB.Items.Add(new OrderItem(new Product("ST-99", "Sticker", 1.5m), 10));
            orderB.PaymentMethod = "PayPal";

            Console.WriteLine($"Base total: {baseOrder.GrandTotal()}");
            Console.WriteLine($"Clone total: {orderB.GrandTotal()}");
        }
    }
}
