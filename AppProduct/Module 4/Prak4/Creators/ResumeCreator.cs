using Lab.Documents.Domain;
namespace Lab.Documents.Creators
{
    public class ResumeCreator : DocumentCreator
    {
        public override IDocument CreateDocument(string title) => new Resume(title);
    }
}
