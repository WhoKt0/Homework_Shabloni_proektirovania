using CafeBeverageDecoratorExtended.Abstractions;

namespace CafeBeverageDecoratorExtended.Decorators
{
    public class Cinnamon : BeverageDecorator
    {
        public Cinnamon(IBeverage beverage) : base(beverage) {}
        public override double GetCost() => base.GetCost() + 8.0;
        public override string GetDescription() => base.GetDescription() + ", Cinnamon";
    }
}
