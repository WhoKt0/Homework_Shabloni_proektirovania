using CafeBeverageDecorator.Abstractions;

namespace CafeBeverageDecorator.Decorators
{
    // Base decorator adhering to Open-Closed Principle and Liskov Substitution.
    public abstract class BeverageDecorator : IBeverage
    {
        protected readonly IBeverage _beverage;
        protected BeverageDecorator(IBeverage beverage) => _beverage = beverage;

        public virtual double GetCost() => _beverage.GetCost();
        public virtual string GetDescription() => _beverage.GetDescription();
    }
}
