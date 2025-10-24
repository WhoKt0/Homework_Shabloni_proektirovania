using System.Text;
using AppProduct.Module_7.Prak7.Reports.Template;

namespace AppProduct.Module_7.Prak7.Reports.Concrete
{
    public class ExcelReport : ReportGenerator
    {
        protected override string Format(string prepared) => prepared.Replace(';', ',');
        protected override string Render(string title, string body)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Title,{title}");
            sb.AppendLine("Body," + body.Replace("\n", " "));
            return sb.ToString();
        }
    }
}
