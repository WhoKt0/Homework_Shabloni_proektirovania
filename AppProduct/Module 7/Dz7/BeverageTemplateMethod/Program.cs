using System;
using AppProduct.Module_7.Dz7.Beverages;

namespace AppProduct.Module_7.Dz7.BeverageApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Чай:");
            Beverage tea = new Tea();
            tea.PrepareRecipe();

            Console.WriteLine("\nКофе:");
            Beverage coffee = new Coffee();
            coffee.PrepareRecipe();

            Console.WriteLine("\nГорячий шоколад:");
            Beverage choco = new HotChocolate();
            choco.PrepareRecipe();
        }
    }
}
