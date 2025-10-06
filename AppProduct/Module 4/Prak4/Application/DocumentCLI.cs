using System;
using System.Collections.Generic;
using Lab.Documents.Domain;
using Lab.Documents.Creators;

namespace Lab.Documents.Application
{
    public class DocumentCLI
    {
        private readonly IDictionary<string, DocumentCreator> _creators;

        public DocumentCLI(IDictionary<string, DocumentCreator> creators)
        {
            _creators = creators;
        }

        public void Run()
        {
            Console.WriteLine("Types: report, resume, letter, invoice");
            Console.Write("Type: ");
            var type = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
            if (!_creators.ContainsKey(type))
            {
                Console.WriteLine("Unknown type");
                return;
            }

            Console.Write("Title: ");
            var title = Console.ReadLine() ?? "Untitled";

            IDocument doc = _creators[type].CreateDocument(title);
            doc.Open();
        }
    }
}
