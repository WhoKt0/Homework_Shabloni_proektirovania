using System.Text;
using AppProduct.Module_7.Prak7.Reports.Template;

namespace AppProduct.Module_7.Prak7.Reports.Concrete
{
    public class PdfReport : ReportGenerator
    {
        protected override string Format(string prepared) => prepared.ToUpperInvariant();
        protected override string Render(string title, string body)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"PDF: {title}");
            sb.AppendLine(new string('-', 20));
            sb.AppendLine(body);
            return sb.ToString();
        }
    }
}
