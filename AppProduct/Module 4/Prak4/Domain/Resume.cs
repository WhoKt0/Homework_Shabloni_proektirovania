using System;
namespace Lab.Documents.Domain
{
    public class Resume : IDocument
    {
        public string Title { get; }
        public Resume(string title) { Title = title; }
        public void Open() => Console.WriteLine($"Resume opened: {Title}");
    }
}
