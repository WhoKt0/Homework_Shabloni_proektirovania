namespace Lab.Documents.Domain
{
    public interface IDocument
    {
        string Title { get; }
        void Open();
    }
}
