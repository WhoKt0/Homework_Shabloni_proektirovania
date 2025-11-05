using CafeBeverageDecoratorExtended.Abstractions;

namespace CafeBeverageDecoratorExtended.Core
{
    public class Espresso : IBeverage
    {
        public double GetCost() => 80.0;
        public string GetDescription() => "Espresso";
    }
}
