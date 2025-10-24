using System.Text;
using AppProduct.Module_7.Prak7.Reports.Template;

namespace AppProduct.Module_7.Prak7.Reports.Concrete
{
    public class CsvReport : ReportGenerator
    {
        protected override string Format(string prepared) => prepared.Replace('\n', ';');
        protected override string Render(string title, string body)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"TITLE;{title}");
            sb.AppendLine($"BODY;{body}");
            return sb.ToString();
        }
    }
}
