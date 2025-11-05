using System;
using CafeBeverageDecoratorExtended.Abstractions;
using CafeBeverageDecoratorExtended.Core;
using CafeBeverageDecoratorExtended.Decorators;

namespace CafeBeverageDecoratorExtended
{
    public static class Program
    {
        public static void Main()
        {
            IBeverage drink = new Latte();
            drink = new Vanilla(drink);
            drink = new Milk(drink);
            drink = new Sugar(drink);
            Console.WriteLine($"{drink.GetDescription()} : {drink.GetCost()}");

            IBeverage second = new Mocha();
            second = new Cinnamon(second);
            second = new WhippedCream(second);
            Console.WriteLine($"{second.GetDescription()} : {second.GetCost()}");
        }
    }
}
