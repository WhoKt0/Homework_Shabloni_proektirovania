using CafeBeverageDecoratorExtended.Abstractions;

namespace CafeBeverageDecoratorExtended.Core
{
    public class Latte : IBeverage
    {
        public double GetCost() => 90.0;
        public string GetDescription() => "Latte";
    }
}
