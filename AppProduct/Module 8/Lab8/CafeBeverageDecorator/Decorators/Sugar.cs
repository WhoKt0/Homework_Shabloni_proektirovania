using CafeBeverageDecorator.Abstractions;

namespace CafeBeverageDecorator.Decorators
{
    public class Sugar : BeverageDecorator
    {
        public Sugar(IBeverage beverage) : base(beverage) {}
        public override double GetCost() => base.GetCost() + 5.0;
        public override string GetDescription() => base.GetDescription() + ", Sugar";
    }
}
