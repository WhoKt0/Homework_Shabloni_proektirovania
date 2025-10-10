using System.Collections.Generic;
using System.Linq;

namespace AppProduct.Module_5.Dz5.Prototype
{
    public class Order : IPrototype<Order>
    {
        public string Customer { get; }
        public List<OrderItem> Items { get; } = new List<OrderItem>();
        public List<Discount> Discounts { get; } = new List<Discount>();
        public decimal ShippingCost { get; set; }
        public string PaymentMethod { get; set; }

        public Order(string customer) { Customer = customer; }

        public decimal Subtotal() => Items.Sum(i => i.LineTotal());
        public decimal TotalDiscount()
        {
            decimal total = 0m;
            var sum = Subtotal();
            foreach (var d in Discounts)
                total += d.IsPercent ? sum * d.Amount : d.Amount;
            return total;
        }
        public decimal GrandTotal() => System.Math.Max(0, Subtotal() - TotalDiscount() + ShippingCost);

        public Order Clone()
        {
            var clone = new Order(Customer) { ShippingCost = ShippingCost, PaymentMethod = PaymentMethod };
            foreach (var it in Items) clone.Items.Add(it.Clone());
            foreach (var d in Discounts) clone.Discounts.Add(d.Clone());
            return clone;
        }
    }
}
