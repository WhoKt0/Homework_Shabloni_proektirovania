using Lab.Documents.Domain;
namespace Lab.Documents.Creators
{
    public class LetterCreator : DocumentCreator
    {
        public override IDocument CreateDocument(string title) => new Letter(title);
    }
}
