using CafeBeverageDecorator.Abstractions;

namespace CafeBeverageDecorator.Decorators
{
    public class WhippedCream : BeverageDecorator
    {
        public WhippedCream(IBeverage beverage) : base(beverage) {}
        public override double GetCost() => base.GetCost() + 15.0;
        public override string GetDescription() => base.GetDescription() + ", Whipped Cream";
    }
}
