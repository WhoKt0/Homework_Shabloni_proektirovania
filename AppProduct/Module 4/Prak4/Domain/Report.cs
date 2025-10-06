using System;
namespace Lab.Documents.Domain
{
    public class Report : IDocument
    {
        public string Title { get; }
        public Report(string title) { Title = title; }
        public void Open() => Console.WriteLine($"Report opened: {Title}");
    }
}
