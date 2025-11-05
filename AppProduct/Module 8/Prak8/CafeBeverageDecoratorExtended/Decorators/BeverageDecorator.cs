using CafeBeverageDecoratorExtended.Abstractions;

namespace CafeBeverageDecoratorExtended.Decorators
{
    public abstract class BeverageDecorator : IBeverage
    {
        protected readonly IBeverage _beverage;
        protected BeverageDecorator(IBeverage beverage) => _beverage = beverage;
        public virtual double GetCost() => _beverage.GetCost();
        public virtual string GetDescription() => _beverage.GetDescription();
    }
}
