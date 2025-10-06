using System.Collections.Generic;
using Lab.Documents.Application;
using Lab.Documents.Creators;

namespace Lab.Documents
{
    class Program
    {
        static void Main()
        {
            var creators = new Dictionary<string, DocumentCreator>
            {
                ["report"] = new ReportCreator(),
                ["resume"] = new ResumeCreator(),
                ["letter"] = new LetterCreator(),
                ["invoice"] = new InvoiceCreator()
            };

            var cli = new DocumentCLI(creators);
            cli.Run();
        }
    }
}
