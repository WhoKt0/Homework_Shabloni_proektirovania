namespace AppProduct.Module_5.Dz5.Prototype
{
    public class Discount : IPrototype<Discount>
    {
        public string Code { get; }
        public decimal Amount { get; }
        public bool IsPercent { get; }
        public Discount(string code, decimal amount, bool isPercent) { Code = code; Amount = amount; IsPercent = isPercent; }
        public Discount Clone() => new Discount(Code, Amount, IsPercent);
    }
}
