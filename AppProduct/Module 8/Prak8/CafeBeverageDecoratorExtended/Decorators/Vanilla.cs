using CafeBeverageDecoratorExtended.Abstractions;

namespace CafeBeverageDecoratorExtended.Decorators
{
    public class Vanilla : BeverageDecorator
    {
        public Vanilla(IBeverage beverage) : base(beverage) {}
        public override double GetCost() => base.GetCost() + 12.0;
        public override string GetDescription() => base.GetDescription() + ", Vanilla";
    }
}
