using System;
using CafeBeverageDecorator.Abstractions;
using CafeBeverageDecorator.Core;
using CafeBeverageDecorator.Decorators;

namespace CafeBeverageDecorator
{
    // Composition Root (manually wiring dependencies without external DI container)
    public static class Program
    {
        public static void Main()
        {
            IBeverage drink = new Espresso();              // base
            drink = new Milk(drink);                       // + milk
            drink = new Sugar(drink);                      // + sugar
            drink = new WhippedCream(drink);               // + cream

            Console.WriteLine($"{drink.GetDescription()} : {drink.GetCost()}");
        }
    }
}
