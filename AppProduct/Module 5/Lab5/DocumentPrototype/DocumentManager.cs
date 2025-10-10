namespace AppProduct.Module_5.Lab5.DocumentPrototype
{
    public class DocumentManager
    {
        public Document CreateDocument(Document prototype) => prototype.Clone();
    }
}
