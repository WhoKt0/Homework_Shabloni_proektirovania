using CafeBeverageDecoratorExtended.Abstractions;

namespace CafeBeverageDecoratorExtended.Decorators
{
    public class Sugar : BeverageDecorator
    {
        public Sugar(IBeverage beverage) : base(beverage) {}
        public override double GetCost() => base.GetCost() + 5.0;
        public override string GetDescription() => base.GetDescription() + ", Sugar";
    }
}
