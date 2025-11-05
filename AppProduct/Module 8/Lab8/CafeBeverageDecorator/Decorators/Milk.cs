using CafeBeverageDecorator.Abstractions;

namespace CafeBeverageDecorator.Decorators
{
    public class Milk : BeverageDecorator
    {
        public Milk(IBeverage beverage) : base(beverage) {}
        public override double GetCost() => base.GetCost() + 10.0;
        public override string GetDescription() => base.GetDescription() + ", Milk";
    }
}
