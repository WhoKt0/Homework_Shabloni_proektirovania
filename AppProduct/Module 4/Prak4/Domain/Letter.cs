using System;
namespace Lab.Documents.Domain
{
    public class Letter : IDocument
    {
        public string Title { get; }
        public Letter(string title) { Title = title; }
        public void Open() => Console.WriteLine($"Letter opened: {Title}");
    }
}
