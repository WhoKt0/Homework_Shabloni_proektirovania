using System.Text;
using AppProduct.Module_7.Prak7.Reports.Template;

namespace AppProduct.Module_7.Prak7.Reports.Concrete
{
    public class HtmlReport : ReportGenerator
    {
        protected override string Format(string prepared) => prepared;
        protected override string Render(string title, string body)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<html><head><meta charset=\"utf-8\"><title>" + title + "</title></head><body>");
            sb.AppendLine("<h1>" + title + "</h1>");
            sb.AppendLine("<pre>" + System.Net.WebUtility.HtmlEncode(body) + "</pre>");
            sb.AppendLine("</body></html>");
            return sb.ToString();
        }
        protected override bool CustomerWantsSave()
        {
            System.Console.Write("Сохранить HTML? (y/n): ");
            var ans = (System.Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            return ans == "y" || ans == "yes" || ans == "да";
        }
    }
}
