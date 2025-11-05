using CafeBeverageDecorator.Abstractions;

namespace CafeBeverageDecorator.Core
{
    public class Espresso : IBeverage
    {
        public double GetCost() => 80.0;
        public string GetDescription() => "Espresso";
    }
}
