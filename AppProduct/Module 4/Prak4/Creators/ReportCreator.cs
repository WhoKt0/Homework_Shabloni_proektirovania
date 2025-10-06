using Lab.Documents.Domain;
namespace Lab.Documents.Creators
{
    public class ReportCreator : DocumentCreator
    {
        public override IDocument CreateDocument(string title) => new Report(title);
    }
}
