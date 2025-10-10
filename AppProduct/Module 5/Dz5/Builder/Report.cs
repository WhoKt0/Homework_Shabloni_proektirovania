using System;

namespace AppProduct.Module_5.Dz5.Builder
{
    public class Report
    {
        public string Header { get; private set; } = "";
        public string Content { get; private set; } = "";
        public string Footer { get; private set; } = "";

        internal void Apply(string header, string content, string footer)
        {
            Header = header ?? "";
            Content = content ?? "";
            Footer = footer ?? "";
        }

        public override string ToString() => $"{Header}\n{Content}\n{Footer}";
    }
}
