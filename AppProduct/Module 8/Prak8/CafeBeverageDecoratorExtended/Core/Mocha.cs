using CafeBeverageDecoratorExtended.Abstractions;

namespace CafeBeverageDecoratorExtended.Core
{
    public class Mocha : IBeverage
    {
        public double GetCost() => 95.0;
        public string GetDescription() => "Mocha";
    }
}
