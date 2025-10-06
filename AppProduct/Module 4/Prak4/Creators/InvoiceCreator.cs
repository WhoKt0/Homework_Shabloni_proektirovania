using Lab.Documents.Domain;
namespace Lab.Documents.Creators
{
    public class InvoiceCreator : DocumentCreator
    {
        public override IDocument CreateDocument(string title) => new Invoice(title);
    }
}
