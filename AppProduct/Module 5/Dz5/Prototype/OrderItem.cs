namespace AppProduct.Module_5.Dz5.Prototype
{
    public class OrderItem : IPrototype<OrderItem>
    {
        public Product Product { get; }
        public int Quantity { get; }
        public OrderItem(Product product, int quantity) { Product = product; Quantity = quantity; }
        public decimal LineTotal() => Product.Price * Quantity;
        public OrderItem Clone() => new OrderItem(Product.Clone(), Quantity);
    }
}
