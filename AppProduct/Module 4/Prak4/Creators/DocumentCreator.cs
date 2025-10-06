using Lab.Documents.Domain;
namespace Lab.Documents.Creators
{
    public abstract class DocumentCreator
    {
        public abstract IDocument CreateDocument(string title);
    }
}
