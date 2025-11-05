using CafeBeverageDecorator.Abstractions;

namespace CafeBeverageDecorator.Core
{
    public class Tea : IBeverage
    {
        public double GetCost() => 50.0;
        public string GetDescription() => "Tea";
    }
}
