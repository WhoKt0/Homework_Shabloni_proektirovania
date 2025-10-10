namespace AppProduct.Module_5.Dz5.Prototype
{
    public class Product : IPrototype<Product>
    {
        public string Sku { get; }
        public string Name { get; }
        public decimal Price { get; }
        public Product(string sku, string name, decimal price) { Sku = sku; Name = name; Price = price; }
        public Product Clone() => new Product(Sku, Name, Price);
    }
}
