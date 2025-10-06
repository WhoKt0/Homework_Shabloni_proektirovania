using System;
namespace Lab.Documents.Domain
{
    public class Invoice : IDocument
    {
        public string Title { get; }
        public Invoice(string title) { Title = title; }
        public void Open() => Console.WriteLine($"Invoice opened: {Title}");
    }
}
